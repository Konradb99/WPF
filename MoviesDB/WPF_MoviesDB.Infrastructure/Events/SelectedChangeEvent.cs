using Prism.Events;
using WPF_MoviesDB.Infrastructure.Models;

namespace WPF_MoviesDB.Infrastructure.Events
{
    public class SelectedChangeEvent : PubSubEvent<Genre>
    {
    }
}