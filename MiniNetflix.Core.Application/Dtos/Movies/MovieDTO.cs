﻿

namespace MiniNetflix.Core.Application.Dtos.Movies
{
    public class MovieDTO
    {
        public int MovieId { get; set; }

        public string MovieName { get; set; } = string.Empty;

        public string CoverImage { get; set; } = string.Empty;

        public int ProducerId { get; set; }
    }
}
