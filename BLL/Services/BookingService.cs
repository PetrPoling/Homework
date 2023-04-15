﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Abstractions.Interfaces;

namespace BLL.Services
{
    public class BookingService : GenericService<Booking>, IBookingService
    {
        private readonly IClassService _classService;
        private readonly IMemberService _memberService;

        public BookingService(IRepository<Booking> repository, IClassService classService, IMemberService memberService)
            : base(repository)
        {
            _classService = classService;
            _memberService = memberService;
        }

        public async Task<Booking> BookClass(Guid memberId, Guid classId) 
        {
            return await _memberService.IBookingService.BookClass(memberId, classId);
        }

        public async Task<List<Booking>> GetBookingsByMember(Guid memberId)
        {
            return await _memberService.BookingRepository.GetBookingsByMember(memberId);
        }

        public async Task<List<Booking>> GetBookingsByClass(Guid classId)
        {
            return await _unitOfWork.BookingRepository.GetBookingsByClass(classId);
        }

        public async Task<List<Booking>> GetBookingsByDate(DateTime date)
        {
            return await _classService.BookingRepository.GetBookingsByDate(date);
        }

        public async Task ConfirmBooking(Guid bookingId)
        {
            return _bookingService.ConfirmBooking(bookingId);
        }
    }
}