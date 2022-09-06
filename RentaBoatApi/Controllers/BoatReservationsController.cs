using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentaBoatApi.Data;
using RentaBoatApi.Models;

namespace RentaBoatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoatReservationsController : Controller
    {

        private readonly RentApiDbContext dbContext;

        public BoatReservationsController(RentApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: BoatReservationsController
        [HttpGet]
        public async Task<IActionResult> GetAllBoatReservations()
        {
            return Ok(await dbContext.BoatReservations.ToListAsync());
        }

        //// POST: BoatReservationsController/Create
        [HttpPost]
        public async Task<IActionResult?> InsertBoatReservation(BoatReservationsModel brm)
        {        
                var boatReservation = new BoatReservationsModel()
                {

                    FirstName = brm.FirstName,
                    LastName = brm.LastName,
                    Phone = brm.Phone,
                    Email = brm.Email,
                    Message = brm.Message,
                    PersonsNumber = brm.PersonsNumber,
                    CheckInDate = brm.CheckInDate,
                    CheckOutDate = brm.CheckOutDate,
                  //  CheckInTime = brm.CheckInTime,
                  //  CheckOutTime = brm.CheckOutTime,
                    IdBoat = brm.IdBoat

                };

                await dbContext.BoatReservations.AddAsync(boatReservation);
                await dbContext.SaveChangesAsync();
                return Ok(boatReservation);
          
        }


        //// GET: BoatReservationsController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: BoatReservationsController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// GET: BoatReservationsController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: BoatReservationsController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: BoatReservationsController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: BoatReservationsController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
