﻿using Libreria.Models.Entities;
using Libreria.Models.Entities.Actions;

namespace Libreria.Service.Models.Responses
{
    public class LibraryModificationResponse //: BaseResponse<bool, Book>
    {
        public BookActions BookAction { get; set; }

    }
}
