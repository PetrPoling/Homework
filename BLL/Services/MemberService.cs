using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Abstractions.Interfaces;

namespace BLL.Services
{
    public class MemberService : GenericService<Member>, IMemberService
    {
        private readonly ISubscriptionService _subscriptionService;

        public MemberService(IRepository<Member> repository, ISubscriptionService subscriptionService) : base(repository)
        {
            _subscriptionService = subscriptionService;
        }

        public async Task<Member> RegisterMember(Member member)
        {
            member.IsActive = true;
            member.SubscriptionStartDate = DateTime.Now;
            member.SubscriptionEndDate = DateTime.Now.AddYears(1);
    
            await _subscriptionService.CreateSubscription(new Subscription
            {
                Member = member.Id,
                Type = member.SubscriptionType,
                StartDate = member.SubscriptionStartDate,
                EndDate = member.SubscriptionEndDate
            });
    
            return await Add(member);
        }
        
        public async Task<List<Member>> GetActiveMembers()
        {
            return await _repository.GetAllAsync(m => m.IsActive == true);
        }

        public async Task<List<Member>> GetMembersBySubscriptionType(string subscriptionType)
        {
            return await _repository.GetByPredicateAsync(member => member.SubscriptionType == subscriptionType);
        }

        public async Task<List<Member>> GetMembersWithUpcomingRenewal(DateTime startDate, DateTime endDate)
        {
            return await _repository.GetByPredicateAsync(member => member.SubscriptionEndDate > startDate && member.SubscriptionEndDate < endDate);
        }

        public async Task<bool> CheckMemberAttendance(Guid memberId, DateTime date)
        {
            var member = await _repository.GetByIdAsync(memberId);
            return member.Attendance.Any(a => a.Date == date);
        }

        public async Task RecordMemberAttendance(Guid memberId, DateTime date)
        {
            var member = await _repository.GetByIdAsync(memberId);
            if (member.Attendance == null)
            {
                member.Attendance = new List<Attendance>();
            }
            member.Attendance.Add(new Attendance { Date = date });
            await _repository.UpdateAsync(memberId, member);
        }
    }
}