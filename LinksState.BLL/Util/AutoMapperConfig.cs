using AutoMapper;
using LinksState.BLL.Models;
using LinksState.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksState.BLL.Util
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<LinkState, LinkStateDTO>().ReverseMap();
                config.CreateMap<CheckRequest, CheckRequestDTO>().ReverseMap();
            });
        }
    }
}
