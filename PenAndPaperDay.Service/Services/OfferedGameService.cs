using System;
using System.Collections.Generic;
using System.Linq;
using PenAndPaperDay.Core.Interfaces.Services;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.DTO.RestDto;
using PenAndPaperDay.Data.Enum;
using PenAndPaperDay.Data.Repositories;

namespace PenAndPaperDay.Service.Services
{
    public class OfferedGameService : IOfferedGameService
    {
        private readonly IOfferedGameRepository _offeredGameRepository;
        private readonly IUserOnOfferedGameRepository _userOnOfferedGameRepository;
        private readonly IOfferedGameOnTagRepository _offeredGameOnTagRepository;
        private readonly ILanguageService _languageService;
        private readonly IUserService _userService;
        //TODO in config
        private readonly string _tagPrefix = "opt-";

        //TODO bad practice, try to refactor
        private readonly IUserRepository _userRepository;
        
        public OfferedGameService(IOfferedGameRepository offeredGameRepository, IUserOnOfferedGameRepository userOnOfferedGameRepository, IUserService userService, ILanguageService languageService, IUserRepository userRepository, IOfferedGameOnTagRepository offeredGameOnTagRepository)
        {
            _offeredGameRepository = offeredGameRepository;
            _userOnOfferedGameRepository = userOnOfferedGameRepository;
            _userService = userService;
            _languageService = languageService;
            _userRepository = userRepository;
            _offeredGameOnTagRepository = offeredGameOnTagRepository;
        }

        public IList<OfferedGameResult> GetOfferedGames(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                IList<OfferedGameDto> offeredGames = _offeredGameRepository.GetAll();

                return offeredGames.Select(game => OfferedGameParse(game)).ToList();
            }
            else
            {
                //Check if user exist
                var user = _userService.GetUser(code);

                IList<OfferedGameDto> offeredGames = _offeredGameRepository.GetAll(code);

                return offeredGames.Select(game => OfferedGameParse(game)).ToList();
            }
        }

        public OfferedGameResult SaveOfferedGame(OfferedGameResult offeredGameResult)
        {
            //TODO Tags and GameMaster code won't be validated
            if (offeredGameResult == null || offeredGameResult.OfferedGameForm == null)
                throw new ArgumentNullException("No OfferedGameForm send");

            if (string.IsNullOrEmpty(offeredGameResult.OfferedGameForm.GameMasterCode))
                throw new ArgumentException("Empty GameMasterCode", nameof(offeredGameResult.OfferedGameForm.GameMasterCode));

            if (string.IsNullOrEmpty(offeredGameResult.OfferedGameForm.Duration))
                throw new ArgumentException("Empty Duration", nameof(offeredGameResult.OfferedGameForm.Duration));

            if (string.IsNullOrEmpty(offeredGameResult.OfferedGameForm.Size))
                throw new ArgumentException("Empty Size", nameof(offeredGameResult.OfferedGameForm.Size));

            if (string.IsNullOrEmpty(offeredGameResult.OfferedGameForm.LanguageCode))
                throw new ArgumentException("Empty LanguageCode", nameof(offeredGameResult.OfferedGameForm.LanguageCode));

            if (!int.TryParse(offeredGameResult.OfferedGameForm.Duration, out int duration))
                throw new ArgumentException("Invalid duration, use integer", offeredGameResult.OfferedGameForm.Duration);

            if (!int.TryParse(offeredGameResult.OfferedGameForm.Size, out int size))
                throw new ArgumentException("Invalid Size, use integer", offeredGameResult.OfferedGameForm.Size);            

            var offeredGameDto = OfferedGameParse(offeredGameResult);

            var notExist = string.IsNullOrEmpty(offeredGameResult.OfferedGameForm.Id) ||
                        offeredGameResult.OfferedGameForm.Id == "0";

            if (notExist)
            {
                offeredGameDto.Id = 0;
                AddGm(offeredGameResult.OfferedGameForm.GameMasterCode, offeredGameDto);
                AddTags(offeredGameResult.OfferedGameForm.Tags, offeredGameDto);
                offeredGameDto = _offeredGameRepository.Insert(offeredGameDto);
            }
            else
            {
                offeredGameDto.Id = int.Parse(offeredGameResult.OfferedGameForm.Id);

                //currently only one gm
                var gm = offeredGameDto.UserOnOfferedGame.FirstOrDefault(o => o.UserType == UserType.GameMaster);
                if (gm != null)
                {
                    offeredGameDto.UserOnOfferedGame.Remove(gm);
                }
                AddGm(offeredGameResult.OfferedGameForm.GameMasterCode, offeredGameDto);

                offeredGameDto.OfferedGameOnTag.Clear();
                AddTags(offeredGameResult.OfferedGameForm.Tags, offeredGameDto);

                offeredGameDto = _offeredGameRepository.Update(offeredGameDto);
            }

            return OfferedGameParse(offeredGameDto);
        }

        public OfferedGameResult GetOfferedGame(int id)
        {
            if (id == 0)
                throw new ArgumentException("Empty id", nameof(id));

            OfferedGameDto offeredGameDto = _offeredGameRepository.GetById(id);
            if (offeredGameDto == null)
                throw new ArgumentException("Invalid offeredGame id", nameof(id));

            return OfferedGameParse(offeredGameDto);
        }

        public bool DeleteOffered(int id)
        {
            if (id == 0)
                throw new ArgumentException("Empty id", nameof(id));

            var offeredGameDto = _offeredGameRepository.GetById(id);
            if (offeredGameDto == null || offeredGameDto.Id == 0)
                throw new ArgumentException("No offeredGame with Id found", nameof(id));

            return _offeredGameRepository.Delete(offeredGameDto);
        }

        private OfferedGameResult OfferedGameParse(OfferedGameDto offeredGameDto)
        {
            OfferedGameResult result = new OfferedGameResult
            {
                OfferedGameForm = new OfferedGameForm
                {
                    Id = offeredGameDto.Id.ToString(),
                    Description = offeredGameDto.Description,
                    Duration = offeredGameDto.Duration.ToString()
                }
            };

            var offeredGameTempDto = _offeredGameRepository.GetById(offeredGameDto.Id);
            if (offeredGameTempDto.UserOnOfferedGame.Any())
            {
                UserOnOfferedGameDto mapping = offeredGameTempDto.UserOnOfferedGame
                    .FirstOrDefault(t => t.UserType == UserType.GameMaster);

                if (mapping != null && mapping.User != null)
                    result.OfferedGameForm.GameMasterCode = mapping.User.Code;
            }
            
            if(offeredGameDto.Language != null)
                result.OfferedGameForm.LanguageCode = offeredGameDto.Language.TwoDigitSeoCode;

            result.OfferedGameForm.Size = offeredGameDto.Size.ToString();

            if (offeredGameDto.OfferedGameOnTag.Any())
            {
                result.OfferedGameForm.Tags = new Dictionary<string, string>();
                foreach (var tag in offeredGameDto.OfferedGameOnTag)
                {
                    result.OfferedGameForm.Tags.Add(_tagPrefix + tag.TagId, "on");
                }
            }

            return result;
        }

        private OfferedGameDto OfferedGameParse(OfferedGameResult offeredGameResult)
        {
            OfferedGameDto offeredGameDto = new OfferedGameDto
            {
                Description = offeredGameResult.OfferedGameForm.Description,
                Duration = int.Parse(offeredGameResult.OfferedGameForm.Duration),
                LanguageId = _languageService.GetLanguageByCode(offeredGameResult.OfferedGameForm.LanguageCode).Id,
                Size = int.Parse(offeredGameResult.OfferedGameForm.Size)
            };

            if (!string.IsNullOrEmpty(offeredGameResult.OfferedGameForm.Id))
                offeredGameDto.Id = int.Parse(offeredGameResult.OfferedGameForm.Id);

            var tempOfferedGame = _offeredGameRepository.GetById(offeredGameDto.Id);
            if (tempOfferedGame != null)
            {
                offeredGameDto.UserOnOfferedGame = _offeredGameRepository.GetById(offeredGameDto.Id).UserOnOfferedGame;
                offeredGameDto.OfferedGameOnTag = _offeredGameRepository.GetById(offeredGameDto.Id).OfferedGameOnTag;
            }

            return offeredGameDto;
        }

        private void AddTags(IDictionary<string, string> tags, OfferedGameDto offeredGame)
        {
            foreach (var tag in tags)
            {
                OfferedGameOnTagDto offeredGameOnTagDto = new OfferedGameOnTagDto {OfferedGameId = offeredGame.Id};

                //GetFrom Setting
                string tagstring = tag.Key.Replace(_tagPrefix, "");
                if (int.TryParse(tagstring, out int tagId))
                {
                    offeredGameOnTagDto.TagId = tagId;
                }

                offeredGame.OfferedGameOnTag.Add(offeredGameOnTagDto);
            }
        }

        private void AddGm(string gameMasterCode, OfferedGameDto offeredGameDto)
        {
            UserOnOfferedGameDto newMapping = new UserOnOfferedGameDto
            {
                OfferedGameId = offeredGameDto.Id,
                UserType = UserType.GameMaster,
                UserId = _userRepository.GetByCode(gameMasterCode).Id
            };
            offeredGameDto.UserOnOfferedGame.Add(newMapping);
        }
    }
}
