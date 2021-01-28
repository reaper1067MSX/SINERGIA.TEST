using AutoMapper;
using Common.TEST.SharedViewModels.Producto;
using MainData.TEST.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.TEST.Models.Mapper
{
    public class MpperProfile: Profile
    {
        public MpperProfile()
        {
            CreateMap<Producto, ProductoVM>().ReverseMap();
        }
    }
}
