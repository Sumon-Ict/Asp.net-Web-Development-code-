using AutoMapper;
using BookSystem.Training.BusinessObjects;
using BookSystem.Training.Exceptions;
using BookSystem.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem.Training.Services
{
    public class AuthorService : IAuthorService
    {

        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IMapper _mapper;



        public AuthorService(ITrainingUnitOfWork trainingUnitOfWork, IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _mapper = mapper;

        }

        public void CreateAuthor(Author author)
        {
            if (author == null)
                throw new InvalidParameterException("author is not provided for create");

            if (IfAlreadyUsed(author.Name))
                throw new DuplicateValueException("this name is already used");

            _trainingUnitOfWork.Authors.Add(_mapper.Map<Entities.Author>(author));
            _trainingUnitOfWork.Save();


        }

        public void DeleteAuthor(int id)
        {
            _trainingUnitOfWork.Authors.Remove(id);
            _trainingUnitOfWork.Save();

        }

        public Author GetAuthor(int id)
        {
            var author = _trainingUnitOfWork.Authors.GetById(id);
            if (author == null)
                return null;

            return _mapper.Map<Author>(author);

        }

        public (IList<Author> records, int total, int totalDisplay) GetAuthors(int pageIndex,
            int pageSize, string searchText, string sortText)
        {

            var authorData = _trainingUnitOfWork.Authors.GetDynamic(string.IsNullOrEmpty(searchText) ?
             null : x => x.Name.Contains(searchText), sortText, string.Empty, pageIndex, pageSize);

            var resultData = (from author in authorData.data
                              select _mapper.Map<Author>(author)).ToList();

            return (resultData, authorData.total, authorData.totalDisplay);

        }


        public void UpdateAuthor(Author author)
        {
            if (author == null)
                throw new InvalidParameterException("author is not provided for update ");

            if (IfAlreadyUsed(author.Name, author.Id))
                throw new DuplicateValueException("this author  name already exist");

            var authorEntity = _trainingUnitOfWork.Authors.GetById(author.Id);

            if (authorEntity != null)
            {
                _mapper.Map(author, authorEntity);
                _trainingUnitOfWork.Save();


            }
            else
                throw new InvalidOperationException("failed to update author");


        }

        private bool IfAlreadyUsed(string name) =>
            _trainingUnitOfWork.Authors.GetCount(x => x.Name == name) > 0;
        private bool IfAlreadyUsed(string name, int id) =>
           _trainingUnitOfWork.Authors.GetCount(x => x.Name == name && x.Id != id) > 0;

    }
}
