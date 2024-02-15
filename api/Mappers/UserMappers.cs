using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Mappers
{
    public class UserMappers
    {
        public static UserRequestDto ToUserRequestDto(this User userModel)
        {
            return new UserRequestDto
            {
                id = userModel.id,
                userName = userModel.userName
            };
        }
        public static User ToUserFromCreateDTO(this CreateUserRequestDto userDto)
        {
            return new User
            {
                userName = userDto.userName,
                password = userDto.password
            };
        }
        public static User UpdateToUserFromUserDTO(this UpdateUserRequestDto updateUserDto, User user)
        {
            user.userName = updateUserDto.userName,
            user.password = updateUserDto.password

            return user;
        }
    }
}