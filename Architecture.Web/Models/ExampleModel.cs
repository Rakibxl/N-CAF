using Architecture.Core.Entities;
using Architecture.Mappings;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Architecture.Web.Models
{
    public class ExampleModel : IMapFrom<Example>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sequence { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Example, ExampleModel>();
        }
    }

    public class SaveExampleModel : IMapFrom<Example>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int Sequence { get; set; }
        public bool IsActive { get; set; }
        public IFormFile ImageFile { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SaveExampleModel, Example>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Name.Trim()));
            profile.CreateMap<Example, SaveExampleModel>();
        }
    }
}
