﻿using AutoMapper;
using PatikaAkbankBookstore.Common;
using PatikaAkbankBookstore.DbOperations;
using PatikaAkbankBookstore.Entities;

namespace PatikaAkbankBookstore.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public AuthorDto model { get; set; }

        public CreateAuthorCommand(BookStoreDbContext dbContext) {
            
            _dbContext = dbContext;

        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.FirstName == model.FirstName && x.LastName == model.LastName);
            if (author is not null)
            {

                throw new InvalidOperationException("Kitap türü zaten Mevcut");

            }
            author = new Author();
            author.FirstName = model.FirstName;
            author.LastName = model.LastName;
            author.BirthDate = model.BirthDate;

            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
        }
    }
}
