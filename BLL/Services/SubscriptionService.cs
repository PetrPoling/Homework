using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Abstractions.Interfaces;

namespace BLL.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IRepository<Subscription> _repository;

        public SubscriptionService(IRepository<Subscription> repository)
        {
            _repository = repository;
        }

        public async Task<Subscription> Create(Subscription subscription)
        {
            await _repository.AddAsync(subscription);
            await _repository.SaveChangesAsync();

            return subscription;
        }

        public async Task<List<Subscription>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Subscription> GetById(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Subscription> Update(Subscription subscription)
        {
            _repository.Update(subscription);
            await _repository.SaveChangesAsync();

            return subscription;
        }

        public async Task<bool> Delete(Guid id)
        {
            var subscription = await _repository.GetByIdAsync(id);

            if (subscription == null)
                return false;

            _repository.Delete(subscription);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<Subscription> CreateSubscription(Subscription subscription)
        {
            return await Create(subscription);
        }

        public async Task<List<Subscription>> GetSubscriptionsByMember(Guid memberId)
        {
            return await _repository.GetAsync(s => s.Member.Id == memberId);
        }

        public async Task<List<Subscription>> GetSubscriptionsByType(string subscriptionType)
        {
            return await _repository.GetAsync(s => s.Type.Name == subscriptionType);
        }

        public async Task RenewSubscription(Guid subscriptionId)
        {
            var subscription = await _repository.GetByIdAsync(subscriptionId);

            if (subscription == null)
                throw new InvalidOperationException($"Subscription with ID {subscriptionId} not found.");

            subscription.StartDate = DateTime.Now;
            subscription.EndDate = subscription.StartDate.Add(subscription.Type.Duration);
            subscription.IsActive = true;

            await Update(subscription);
        }

        public async Task CancelSubscription(Guid subscriptionId)
        {
            var subscription = await _repository.GetByIdAsync(subscriptionId);

            if (subscription == null)
                throw new InvalidOperationException($"Subscription with ID {subscriptionId} not found.");

            subscription.IsActive = false;

            await Update(subscription);
        }
    }
}
