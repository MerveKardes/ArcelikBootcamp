﻿using MediatR;

namespace WebAPI.Application.CQRS.Commands
{
    public class UpdateMovieCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string ImageUrl { get; set; } = String.Empty;
        public string Summary { get; set; } = String.Empty;
        public string Director { get; set; } = String.Empty;
        public int Point { get; set; }
        public bool IsFavorite { get; set; }
    }
}
