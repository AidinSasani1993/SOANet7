using Ceal.Dapper;
using Clean.Application.Models;
using Clean.Application.Models.Report;
using Clean.Application.Repositories;
using MehrSepand.Framework.Common.CommonViewModels;
using MehrSepand.Framework.Common.Exceptions;
using MehrSepand.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanService.Person
{
    public class PersonService
    {


        private readonly IPersonRepository _countryRepository;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;   // Add mapper
        private readonly PersonDapperService _countryDapperService;

        //public PersonService(ICountryRepository countryRepository,
        //                      IUnitOfWork unitOfWork,
        //                      IMapper mapper,
        //                      ICountryDapperService countryDapperService)
        //{
        //    _countryRepository = countryRepository;
        //    _unitOfWork = unitOfWork;
        //    _mapper = mapper;
        //    _countryDapperService = countryDapperService;
        //}



        public async Task<ResponseResultViewModel<PaginateViewModel<IEnumerable<QueryCountryDetailViewModel>>>> GetDapperService()
        {
            var result = new ResponseResultViewModel<PaginateViewModel<IEnumerable<QueryCountryDetailViewModel>>>();

            try
            {
                var resultModel = new PaginateViewModel<IEnumerable<QueryCountryDetailViewModel>>();
                var resultData = await _countryDapperService.GetPerson();
                resultModel.Records = resultData.QueryCountryDetails;
                return result.WithData(resultModel);
            }
            catch (Exception ex)
            {
                throw new MehrSepandException(ex.Message);
            }

        }


    }
}
