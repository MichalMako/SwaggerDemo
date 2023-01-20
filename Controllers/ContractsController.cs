using SwaggerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SwaggerDemo.Controllers
{
    public class ContractsController : ApiController
    {
        private Contract[] _contracts = new[]
        {
            new Contract
            {
                Id = 1,
                Name = "Test 1",
                Date = DateTime.Now
            },
            new Contract
            {
                Id = 2,
                Name = "Test 2",
                Date = DateTime.Now
            },
            new Contract
            {
                Id = 3,
                Name = "Test 3",
                Date = DateTime.Now
            }
        };

        public List<Contract> GetList()
        {
            return _contracts.ToList();
        }

        public Contract Get(int? id) => _contracts.FirstOrDefault(c => c.Id == id);

        [HttpPost]
        public List<Contract> Edit(Contract contract)
        {
            _ = contract ?? throw new ArgumentNullException(nameof(contract));
            if (contract.Id <= 0)
            {
                throw new InvalidOperationException("Input Contract has not valid ID");
            }

            var existingContract = _contracts.FirstOrDefault(c => c.Id == contract.Id);
            if (existingContract == null)
            {
                _contracts = _contracts.Append(contract).ToArray();
            }
            else
            {
                existingContract.Name = contract.Name;
                existingContract.Date = contract.Date;
            }

            return _contracts.ToList();
        }
    }
}
