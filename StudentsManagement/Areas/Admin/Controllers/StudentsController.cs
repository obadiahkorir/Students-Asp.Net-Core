using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Students.Business.Common;
using Students.Business.Models;
using Students.Business.ViewModels;
using StudentsManagement.Data;


using X.PagedList;

namespace StudentsManagement.Areas.Admin
{
    [Area("Admin")]
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        
        }

        // GET: Admin/Students
        public async Task<IActionResult> Index(StudentViewModel vm)
        {
            var data =  _context.Students.Include(s => s.County).Include(s => s.Course);

            var pageSize = vm.PageSize ?? 100;
            var page = vm.Page ?? 1;

            ViewBag.PageSize = this.GetPager(vm.PageSize);

            vm.Students = data.ToPagedList(page, pageSize);

            return View(vm);
        }


        // GET: Admin/Students/Details/5
        public async Task<IActionResult> Details(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsModel = await _context.Students
                .Include(s => s.County)
                .Include(s => s.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentsModel == null)
            {
                return NotFound();
            }

            return View(studentsModel);
        }

        // GET: Admin/Students/Create
        public IActionResult Create()
        {
            ViewData["CountyId"] = new SelectList(_context.County, "Id", "CountyName");
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "CourseName");

            return View();
        }

        // POST: Admin/Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel studentsModel)
        {
            if (ModelState.IsValid)
            {

                var student = new StudentsModel();
                new MapperConfiguration(cfg => { cfg.CreateMap<StudentViewModel, StudentsModel>(); })
                       .CreateMapper().Map(studentsModel, student);

                _context.Add(student);
                await _context.SaveChangesAsync();
               return RedirectToAction(nameof(Index));
            }
            ViewData["CountyId"] = new SelectList(_context.County, "Id", "Id", studentsModel.CountyId);
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", studentsModel.CourseId);
            return View(studentsModel);
        }

        // GET: Admin/Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsModel = await _context.Students.FindAsync(id);
            if (studentsModel == null)
            {
                return NotFound();
            }
            ViewData["CountyId"] = new SelectList(_context.County, "Id", "Id", studentsModel.CountyId);
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", studentsModel.CourseId);
            return View(studentsModel);
        }

        // POST: Admin/Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,OtherName,EthnicityId,CountyId,DOB,CourseId,TelephoneNo,IdNumber")] StudentsModel studentsModel)
        {
            if (id != studentsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsModelExists(studentsModel.Id))
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
            ViewData["CountyId"] = new SelectList(_context.County, "Id", "CountyName", studentsModel.CountyId);
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "CourseName", studentsModel.CourseId);
            return View(studentsModel);
        }

        // GET: Admin/Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsModel = await _context.Students
                .Include(s => s.County)
                .Include(s => s.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentsModel == null)
            {
                return NotFound();
            }

            return View(studentsModel);
        }

        // POST: Admin/Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentsModel = await _context.Students.FindAsync(id);
            _context.Students.Remove(studentsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsModelExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
