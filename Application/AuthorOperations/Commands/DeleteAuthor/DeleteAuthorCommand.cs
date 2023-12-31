﻿using PatikaAkbankBookstore.DbOperations;

namespace PatikaAkbankBookstore.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        public int AuthorId { get; set; }

        public DeleteAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x=> x.Id == AuthorId);

            if (author == null)
            {
                throw new InvalidOperationException("Yazar Bulunamadı");
            }
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }
    }
}
