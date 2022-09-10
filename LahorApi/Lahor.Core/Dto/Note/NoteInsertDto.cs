﻿using Lahor.Core.Entities.Identity;

namespace Lahor.Core.Dto.Note
{
    public class NoteInsertDto
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public bool Public { get; set; }
    }
}
