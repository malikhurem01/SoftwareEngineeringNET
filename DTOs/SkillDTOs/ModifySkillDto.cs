﻿namespace ResumeMaker.API.DTOs.SkillDTOs
{
    public class ModifySkillDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
    }
}
