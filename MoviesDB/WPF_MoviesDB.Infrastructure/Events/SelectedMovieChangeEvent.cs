﻿using Prism.Events;
using WPF_MoviesDB.Infrastructure.Models;

namespace WPF_MoviesDB.Infrastructure.Events
{
    public class SelectedMovieChangeEvent : PubSubEvent<Movie>
    {
    }
}