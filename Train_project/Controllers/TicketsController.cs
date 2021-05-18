using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Train_project.Data;
using Train_project.Models;

namespace Train_project.Controllers
{
    public class TicketsController : Controller
    {
        private readonly TrainContext _context;

        public TicketsController(TrainContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var trainContext = _context.Tickets.Include(t => t.Class).Include(t => t.Passenger).Include(t => t.Promotion).Include(t => t.Route).Include(t => t.Schedule).Include(t => t.Train);
            return View(await trainContext.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.Class)
                .Include(t => t.Passenger)
                .Include(t => t.Promotion)
                .Include(t => t.Route)
                .Include(t => t.Schedule)
                .Include(t => t.Train)
                .FirstOrDefaultAsync(m => m.T_id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            ViewData["ClassC_id"] = new SelectList(_context.Class, "C_id", "C_id");
            ViewData["PassengerP_id"] = new SelectList(_context.Passengers, "P_id", "P_id");
            ViewData["PromotionPromotion_id"] = new SelectList(_context.Promotions, "Promotion_id", "Promotion_id");
            ViewData["RouteR_id"] = new SelectList(_context.Routes, "R_id", "R_id");
            ViewData["ScheduleQ_id"] = new SelectList(_context.Schedules, "Q_id", "Q_id");
            ViewData["TrainTR_id"] = new SelectList(_context.Trains, "TR_id", "TR_id");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("T_id,date_issued,PassengerP_id,TrainTR_id,ClassC_id,RouteR_id,ScheduleQ_id,PromotionPromotion_id")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassC_id"] = new SelectList(_context.Class, "C_id", "C_id", ticket.ClassC_id);
            ViewData["PassengerP_id"] = new SelectList(_context.Passengers, "P_id", "P_id", ticket.PassengerP_id);
            ViewData["PromotionPromotion_id"] = new SelectList(_context.Promotions, "Promotion_id", "Promotion_id", ticket.PromotionPromotion_id);
            ViewData["RouteR_id"] = new SelectList(_context.Routes, "R_id", "R_id", ticket.RouteR_id);
            ViewData["ScheduleQ_id"] = new SelectList(_context.Schedules, "Q_id", "Q_id", ticket.ScheduleQ_id);
            ViewData["TrainTR_id"] = new SelectList(_context.Trains, "TR_id", "TR_id", ticket.TrainTR_id);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["ClassC_id"] = new SelectList(_context.Class, "C_id", "C_id", ticket.ClassC_id);
            ViewData["PassengerP_id"] = new SelectList(_context.Passengers, "P_id", "P_id", ticket.PassengerP_id);
            ViewData["PromotionPromotion_id"] = new SelectList(_context.Promotions, "Promotion_id", "Promotion_id", ticket.PromotionPromotion_id);
            ViewData["RouteR_id"] = new SelectList(_context.Routes, "R_id", "R_id", ticket.RouteR_id);
            ViewData["ScheduleQ_id"] = new SelectList(_context.Schedules, "Q_id", "Q_id", ticket.ScheduleQ_id);
            ViewData["TrainTR_id"] = new SelectList(_context.Trains, "TR_id", "TR_id", ticket.TrainTR_id);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("T_id,date_issued,PassengerP_id,TrainTR_id,ClassC_id,RouteR_id,ScheduleQ_id,PromotionPromotion_id")] Ticket ticket)
        {
            if (id != ticket.T_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.T_id))
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
            ViewData["ClassC_id"] = new SelectList(_context.Class, "C_id", "C_id", ticket.ClassC_id);
            ViewData["PassengerP_id"] = new SelectList(_context.Passengers, "P_id", "P_id", ticket.PassengerP_id);
            ViewData["PromotionPromotion_id"] = new SelectList(_context.Promotions, "Promotion_id", "Promotion_id", ticket.PromotionPromotion_id);
            ViewData["RouteR_id"] = new SelectList(_context.Routes, "R_id", "R_id", ticket.RouteR_id);
            ViewData["ScheduleQ_id"] = new SelectList(_context.Schedules, "Q_id", "Q_id", ticket.ScheduleQ_id);
            ViewData["TrainTR_id"] = new SelectList(_context.Trains, "TR_id", "TR_id", ticket.TrainTR_id);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.Class)
                .Include(t => t.Passenger)
                .Include(t => t.Promotion)
                .Include(t => t.Route)
                .Include(t => t.Schedule)
                .Include(t => t.Train)
                .FirstOrDefaultAsync(m => m.T_id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.T_id == id);
        }
    }
}
