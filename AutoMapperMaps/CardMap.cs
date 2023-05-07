﻿using AutoMapper;

namespace ResumeMaker.API.AutoMapperMaps
{
    public class CardMap : Profile
    {
        public CardMap() {
            CreateMap<AddCardDto, Card>();
            CreateMap<GetCardDto, AddCardDto>();
            CreateMap<GetCardDto, Card>();
            CreateMap<AddCardDto, GetCardDto>();
            CreateMap<Card, GetCardDto>();
            CreateMap<ModifyCardDto, Card>();
        }
    }
}
