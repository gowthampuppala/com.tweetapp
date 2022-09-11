﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace com.tweetapp.Domain.Input
{
    public class ResetPasswordDto
    {
        [Required]
        [StringLength(20, ErrorMessage = "Password length must be between 6 to 20", MinimumLength = 6)]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Password length must be between 6 to 20", MinimumLength = 6)]
        public string NewPassword { get; set; }
    }
}
