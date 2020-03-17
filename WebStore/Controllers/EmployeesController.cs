using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _EmployeesData;

        public EmployeesController(IEmployeesData EmployeesData)
        {
            _EmployeesData = EmployeesData;
        }
        public IActionResult EmployeesList()
        {
            return View(DataEmployees.Employees);
        }

        public IActionResult EmployeeCard(int Id)
        {
            var employee = _EmployeesData.GetById(Id);
            if (employee is null)
                return NotFound();
            
            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.FirstName,
                SecondName = employee.SurName,
                Patronymic = employee.Patronymic,
                Age = employee.Age
            }); ;
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel Employee)
        {
            if (Employee is null)
                throw new ArgumentNullException(nameof(Employee));

            if (Employee.Name == "123" && Employee.SecondName == "QWE")
                ModelState.AddModelError(string.Empty, "Странные имя и фамилия...");

            if (!ModelState.IsValid)
                return View(Employee);

            var id = Employee.Id;
            if (id == 0)
                _EmployeesData.Add(new Employee
                {
                    FirstName = Employee.Name,
                    SurName = Employee.SecondName,
                    Patronymic = Employee.Patronymic,
                    Age = Employee.Age
                });
            else
                _EmployeesData.Edit(id, new Employee
                {
                    FirstName = Employee.Name,
                    SurName = Employee.SecondName,
                    Patronymic = Employee.Patronymic,
                    Age = Employee.Age
                });

            _EmployeesData.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var employee = _EmployeesData.GetById(id);
            if (employee is null)
                return NotFound();

            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.FirstName,
                SecondName = employee.SurName,
                Patronymic = employee.Patronymic,
                Age = employee.Age
            });
        }

        public IActionResult DeleteConfirmed(int id)
        {
            _EmployeesData.Delete(id);
            _EmployeesData.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}