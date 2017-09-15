﻿using System.Threading.Tasks;
using CoTech.Bi.Modules.Expenses.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoTech.Bi.Modules.Expenses.Controllers{
    [Route("api/expenseGroups")]
    public class ExpenseGroupController{
        private readonly ExpenseGroupRepository expenseRepo;

        public ExpenseGroupController(ExpenseGroupRepository expenseRepo){
            this.expenseRepo = expenseRepo;
        }
        
        [HttpGet]
        public async Task<IActionResult> getAll(){
            return new OkObjectResult(await expenseRepo.getAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id){
            return new OkObjectResult(await expenseRepo.WithId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExpenseGroupReq req){
            var expense = req.toEntity();
            await expenseRepo.Create(expense);
            return new OkObjectResult(expense);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateExpenseGroupReq req){
            var result = await expenseRepo.Update(id, req);
            return new OkObjectResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id){
            var provider = await expenseRepo.WithId(id);
            await expenseRepo.Delete(provider);
            return new OkObjectResult(provider);
        }
    }
    
}