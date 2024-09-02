using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.Repositories.IRepositories;
using WebAPIDemo.Services.Services.IServices;

namespace WebAPIDemo.Services.Services
{
    public class EventService(IUnitOfWork unitOfWork) : IEventService
    {
        public async Task<List<EventDTO>?> GetAllEvents()
        {
            try
            {
                return await unitOfWork.Events.GetAllEvents();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<EventDTO>?> GetEventByCategory(int CategoryId)
        {
            try
            {
                return await unitOfWork.Events.GetEventByCategory(CategoryId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<EventDTO>?> GetEventByUser(int UserId)
        {
            try
            {
                return await unitOfWork.Events.GetEventByUser(UserId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Event?> createEvent(Event _event)
        {
            try
            {
                await unitOfWork.Events.AddAsync(_event);
                await unitOfWork.CommitAsync();
                return _event;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<Event?> UpdateEvent(Event _event)
        {
            try
            {
                // Fetch the existing event
                Event existingEvent = await unitOfWork.Events.GetByIdAsync(_event.Id);
                if (existingEvent == null)
                {
                    throw new NotFoundException("Event Not Found");
                }

             
                existingEvent.Name = _event.Name;
                existingEvent.CategoryId = _event.CategoryId; 
                existingEvent.Cost = _event.Cost; 
                existingEvent.Destination = _event.Destination;
                existingEvent.EventDate = _event.EventDate;
                existingEvent.Status = _event.Status;
                existingEvent.UserId = _event.UserId;
                await unitOfWork.Events.UpdateAsync(existingEvent);
                await unitOfWork.CommitAsync();

                return existingEvent; 
            }
            catch (DbUpdateConcurrencyException ex)
            {
                
                Console.WriteLine("Concurrency conflict: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<bool> DeleteEvent(int eventId)
        {
            var ExistingEvent = unitOfWork.Events.GetByIdAsync(eventId);
            if (ExistingEvent.IsCanceled) return false;
            await unitOfWork.Events.DeleteEvent(eventId);
            return true;
        }
        public async Task<Event?> GetEventById(int eventId)
        {
            try
            {
                var _event = await unitOfWork.Events.GetByIdAsync(eventId);
                return _event;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


    }
}

