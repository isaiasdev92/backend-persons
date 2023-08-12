using AutoMapper;
using ExameSoftware.Dtos;
using ExameSoftware.Models;

namespace ExameSoftware.Helpers.AutoMap
{
	public class AutoMapper : Profile
	{
		public AutoMapper()
		{
			CreateMap<People, PeopleItem>();
			CreateMap<PeopleRequest, People>();
        }
	}
}

