using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Mappers
{
    public class AnimeMappers
    {
        public static AnimeRequestDto ToAnimeRequestDto(this Anime animeModel)
        {
            return new AnimeRequestDto
            {
                id = animeModel.id,
                name = animeModel.name,
                status = animeModel.status
            };
        }
        public static Anime ToAnimeFromCreateDTO(this CreateAnimeRequestDto animeDto)
        {
            return new Anime
            {
                name = animeDto.name,
                status = animeDto.status
            };
        }
        public static Anime UpdateToAnimeFromAnimeDTO(this UpdateAnimeRequestDto updateAnimeDto, Anime anime)
        {
            anime.name = updateAnimeDto.name,
            anime.status = updateAnimeDto.status

            return anime;
        }
    }
}