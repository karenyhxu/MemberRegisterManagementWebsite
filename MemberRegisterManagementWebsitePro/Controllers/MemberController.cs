using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MemberRegisterManagementWebsitePro.Models;
using MemberRegisterManagementWebsitePro.Data;
using Microsoft.EntityFrameworkCore;

namespace MemberRegisterManagementWebsitePro.Controllers {
    public class MemberController : Controller {
        private readonly MemberContext _context;

        public MemberController(MemberContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index() {
            return View(await _context.Members.ToListAsync());
        }

        public async Task<IActionResult> Delete(int? id) {
            var member = await _context.Members.FindAsync(id);
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add() {
            return View(new Member());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("MemberId,FirstName,LastName,Email,PhoneNumber")] Member member) {
            if (ModelState.IsValid) {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        public IActionResult Edit(int id) {
            return View(_context.Members.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("MemberId,FirstName,LastName,Email,PhoneNumber,DateTimeBecameTheMember")] Member member) {
            if (ModelState.IsValid) {
                _context.Update(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }
    }
}
