using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Abstractions.Interfaces;

namespace BLL.Services
{
    public class ClassService : GenericService<FitnessClass>, IClassService
    {
        private readonly IRepository<FitnessClass> _repository;
        private readonly ITrainerService _trainerService;

        public ClassService(IRepository<FitnessClass> repository, ITrainerService trainerService)
        {
            _repository = repository;
            _trainerService = trainerService;
        }

        public async Task Add(FitnessClass fitnessClass)
        {
            try
            {
                var result = await _repository.AddAsync(fitnessClass);

                if (!result.IsSuccessful)
                {
                    throw new Exception($"Failed to add {typeof(FitnessClass).Name}.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add {typeof(FitnessClass).Name}. Exception: {ex.Message}");
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var result = await _repository.DeleteAsync(id);

                if (!result.IsSuccessful)
                {
                    throw new Exception($"Failed to delete {typeof(FitnessClass).Name} with Id {id}.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Failed to delete {typeof(FitnessClass).Name} with Id {id}. Exception: {ex.Message}");
            }
        }

        public async Task<FitnessClass> GetById(Guid id)
        {
            try
            {
                var result = await _repository.GetByIdAsync(id);

                if (!result.IsSuccessful)
                {
                    throw new Exception($"Failed to get {typeof(FitnessClass).Name} by Id {id}.");
                }

                return result.Data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get {typeof(FitnessClass).Name} by Id {id}. Exception: {ex.Message}");
            }
        }

        public async Task<List<FitnessClass>> GetAll()
        {
            try
            {
                var result = await _repository.GetAllAsync();

                if (!result.IsSuccessful)
                {
                    throw new Exception($"Failed to get all {typeof(FitnessClass).Name}s.");
                }

                return result.Data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get all {typeof(FitnessClass).Name}s. Exception: {ex.Message}");
            }
        }

        public async Task<FitnessClass> GetByPredicate(Func<FitnessClass, bool> predicate)
        {
            try
            {
                var result = await _repository.GetByPredicateAsync(predicate);

                if (!result.IsSuccessful)
                {
                    throw new Exception($"Failed to get by predicate {typeof(FitnessClass).Name}s.");
                }

                return result.Data;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Failed to get by predicate {typeof(FitnessClass).Name}s. Exception: {ex.Message}");
            }
        }

        public async Task Update(Guid id, FitnessClass fitnessClass)
        {
            try
            {
                var result = await _repository.UpdateAsync(id, fitnessClass);

                if (!result.IsSuccessful)
                {
                    throw new Exception($"Failed to update {typeof(FitnessClass).Name} with Id {id}.");
                }
            }
            catch (Exception ex)
            {
                public async Task<List<FitnessClass>> GetClassesByTrainer(Guid trainerId)
                {
                    try
                    {
                        var trainer = await _trainerService.GetById(trainerId);

                        if (trainer == null)
                        {
                            throw new Exception($"Trainer with Id {trainerId} not found.");
                        }

                        var classes = await GetAll();

                        return classes.FindAll(c => c.Trainer.Id == trainerId);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(
                            $"Failed to get classes by trainer with Id {trainerId}. Exception: {ex.Message}");
                    }
                }
            }
        }
    }
}

               
