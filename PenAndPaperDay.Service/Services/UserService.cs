using System;
using System.Collections.Generic;
using System.Linq;
using PenAndPaperDay.Core.Interfaces.Services;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.DTO.RestDto;
using PenAndPaperDay.Data.Repositories;

namespace PenAndPaperDay.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool DeleteUser(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentException("Empty code", nameof(code));

            var userDto = _userRepository.GetByCode(code);
            if (userDto == null || userDto.Id == 0)
                throw new ArgumentException("No user with code found", nameof(code));

            return _userRepository.Delete(userDto);
        }

        public UserResult GetUser(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentException("Empty code", nameof(code));

            var userDto = _userRepository.GetByCode(code);
            if (userDto == null || userDto.Id == 0)
                throw new ArgumentException("No user with code found", nameof(code));

            return UserParse(userDto);
        }

        public IList<UserResult> GetUsers(int pos, int count, bool asc)
        {
            if (count <= 0)
                throw new ArgumentException("invalid count", nameof(count));

            IList<UserDto> users = _userRepository.GetUsers(pos, count, asc);

            return users.Select(user => UserParse(user)).ToList();
        }

        public UserResult SaveUser(UserResult userResult)
        {
            if (userResult == null || userResult.UserForm == null)
                throw new ArgumentNullException("No UserForm send");

            if (string.IsNullOrEmpty(userResult.UserForm.Email))
                throw new ArgumentException("Email empty", nameof(userResult.UserForm.Email));

            if (string.IsNullOrEmpty(userResult.UserForm.Name))
                throw new ArgumentException("Name empty", nameof(userResult.UserForm.Name));

            var userDto = UserParse(userResult);

            if (string.IsNullOrEmpty(userResult.UserForm.Code) || userResult.UserForm.Code == "")
            {
                userDto.Id = 0;
                userDto.Code = GenerateCode();
                userDto = _userRepository.Insert(userDto);
            }
            else
            {
                userDto = _userRepository.Update(userDto);
            }

            return UserParse(userDto);
        }

        private UserResult UserParse(UserDto userDto)
        {
            UserResult userResult = new UserResult
            {
                UserForm = new UserForm
                {
                    Code = userDto.Code,
                    Email = userDto.Email,
                    Name = userDto.Name,
                    Notes = userDto.Notes
                }
            };

            return userResult;
        }

        private UserDto UserParse(UserResult userResult)
        {
            UserDto userDto = new UserDto
            {
                Code = userResult.UserForm.Code,
                Email = userResult.UserForm.Email,
                Name = userResult.UserForm.Name,
                Notes = userResult.UserForm.Notes
            };

            return userDto;
        }

        private string GenerateCode()
        {
            Guid g = Guid.NewGuid();
            string guidString = Convert.ToBase64String(g.ToByteArray());
            guidString = guidString.Replace("=", "");
            guidString = guidString.Replace("+", "");
            guidString = guidString.Replace("/", "");

            return guidString;
        }
    }
}
