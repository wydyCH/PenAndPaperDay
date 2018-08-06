using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data.Repositories
{
    public class OfferedGameRepository : BaseRepository<OfferedGame, OfferedGameDto>, IOfferedGameRepository
    {
        public OfferedGameRepository(PenAndPaperDBContext dbContext, ILogger<OfferedGameRepository> logger, IMapper mapper) : base(dbContext, logger, mapper)
        {
        }

        public IList<OfferedGameDto> GetAll(string code)
        {
            var games = _dbContext.UserOnOfferedGames
                .Where(i => i.User.Code == code).Select(s => s.OfferdGame);

            if (games.Any())
            {
                games = games.Distinct();
                return _mapper.Map<IList<OfferedGame>, IList<OfferedGameDto>>(games.ToList());
            }
            else
            {
                return new List<OfferedGameDto>();
            }
        }

        public new IList<OfferedGameDto> GetAll()
        {
            var games = _dbContext.OfferedGames
                .Include(t => t.Language)
                .Include(s => s.UserOnOfferedGame)
                .ThenInclude(u => u.User)
                .Include(v => v.OfferedGameOnTag)
                .ThenInclude(w => w.Tag);

            if (games.Any())
            {
                return _mapper.Map<IList<OfferedGame>, IList<OfferedGameDto>>(games.ToList());
            }

            return new List<OfferedGameDto>();
        }

        public new OfferedGameDto GetById(object id)
        {
            var game = _dbContext.OfferedGames
                .Include(s => s.Language)
                .Include(t => t.UserOnOfferedGame)
                .ThenInclude(u => u.User)
                .Include(v => v.OfferedGameOnTag)
                .ThenInclude(w => w.Tag)
                .FirstOrDefault(i => i.Id == (int)id);

            if (game != null)
            {
                return _mapper.Map<OfferedGame, OfferedGameDto>(game);
            }

            return null;
        }

        public new OfferedGameDto Update(OfferedGameDto offeredGameDto)
        {
            //Problem child table clear.
            var offeredGame = _dbContext.Find<OfferedGame>(offeredGameDto.Id);
            offeredGame = _mapper.Map<OfferedGameDto, OfferedGame>(offeredGameDto);

            var tags = _dbContext.OfferedGameOnTags.Where(of => of.OfferedGameId == offeredGame.Id);
            _dbContext.OfferedGameOnTags.RemoveRange(tags);

            var customers = _dbContext.UserOnOfferedGames.Where(of => of.OfferedGameId == offeredGame.Id);
            _dbContext.UserOnOfferedGames.RemoveRange(customers);

            _dbContext.OfferedGameOnTags.AddRange(offeredGame.OfferedGameOnTag);
            _dbContext.UserOnOfferedGames.AddRange(offeredGame.UserOnOfferedGame);

            _dbContext.SaveChanges();

            return _mapper.Map<OfferedGame, OfferedGameDto>(offeredGame);
        }

        public new bool Delete(OfferedGameDto offeredGameDto)
        {
            var offeredGame = _dbContext.Find<OfferedGame>(offeredGameDto.Id);
            _dbContext.OfferedGames.Remove(offeredGame);

            _dbContext.SaveChanges();

            return true;
        }
    }
}
