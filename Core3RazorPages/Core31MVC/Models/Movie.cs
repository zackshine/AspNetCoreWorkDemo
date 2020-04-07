using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core31MVC.Models
{
    public interface IEntity
    {

    }
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }
    }

    public class Movie : EntityBase
    {
        public string Name { get; set; }
        public List<MovieVersion> MovieVersions { get; set; }
    }

    public class MovieVersion : EntityBase
    {
        public string Name { get; set; }
    }
}
