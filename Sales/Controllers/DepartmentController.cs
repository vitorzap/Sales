using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sales.Models;
using Sales.DBContexts;
using Sales.Repositories.Interfaces;
using Sales.Services;
using Sales.Services.Interfaces;

namespace Sales.Controllers
{
    public class DepartmentController : Controller
    {
        //private readonly SalesDb_context __context;

        //public DepartmentController(SalesDb_context _context)
        //{
        //    __context = _context;
        //}


        private IDepartmentRepository _departmentRepository;
        private IDepartmentService _departmentService;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
       
            _departmentService = new DepartmentService(_departmentRepository);
        }
        // GET: Department
        public async Task<IActionResult> Index()
        {
            //return View(await __context.Department.ToListAsync());
            return View(await _departmentService.GetAll());
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var department = await __context.Department
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var department = await _departmentService.GetById(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Department department)
        //public async Task<IActionResult> Create([Bind("Id,Name")] Department department)
        {
            if (ModelState.IsValid)
            {


                //__context.Add(department);
                //await __context.SaveChangesAsync();

                await _departmentService.Insert(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var department = await __context.Department.FindAsync(id);

            var department = await _departmentService.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //__context.Update(department);
                    //await __context.SaveChangesAsync();

                    await _departmentService.Update(department);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var department = await __context.Department
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var department = await _departmentService.GetById(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var department = await __context.Department.FindAsync(id);
            //__context.Department.Remove(department);
            //await __context.SaveChangesAsync();
           //var department = _departmentRepository.GetById(id);
            await _departmentService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
            return _departmentService.Exists(id);
        }
    }
}
