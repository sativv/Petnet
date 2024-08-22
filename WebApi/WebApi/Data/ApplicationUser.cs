﻿using Microsoft.AspNetCore.Identity;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationUser : IdentityUser
    {


        public bool IsPrivateSeller { get; set; }
        public bool IsVerified { get; set; }
        public List<PostModel> Posts { get; set; } = new List<PostModel>();
        public List<InterestModel> Interests { get; set; } = new List<InterestModel>();
        public List<ReviewModel> ReviewsWritten { get; set; } = new List<ReviewModel>();
        public List<ReviewModel> ReviewsRecieved { get; set; } = new List<ReviewModel>();


    }
}
