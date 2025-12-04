using Microsoft.EntityFrameworkCore;
using twotable.Models;
using twotable.Repository;

namespace twotable.Services
{
    public class SqlEmployeeService : IEmployeeService
    {
        private readonly AppdbContextRepository context;
        public SqlEmployeeService(AppdbContextRepository context)
        {
            this.context = context;
        }
        public Employee Add(Employee employee)
        {
            context.Employee.Add(employee);
            context.SaveChanges();//imp without this query wont fire
            return employee;
        }

        public Employee? Delete(int Id)
        {
            Employee? e = context.Employee.FirstOrDefault(m => m.Id == Id);
            if (e != null)
            {
                context.Employee.Remove(e);
                context.SaveChanges();
            }
            return e;
        }

        public IEnumerable<Department> GetAllDepartment()
        {
            return context.Department;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return context.Employee.Include(dpt => dpt.Department).ToList();

        }

        public Employee? GetEmployee(int Id)
        {
            Employee e = context.Employee.FirstOrDefault(m => m.Id == Id);
            return e;
        }

        public Employee? Update(Employee employeeChanges)
        {
            var tracked = context.Employee.Local.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (tracked != null)
                context.Entry(tracked).State = EntityState.Detached;

            context.Attach(employeeChanges);
            context.Entry(employeeChanges).State = EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }


    }
}
