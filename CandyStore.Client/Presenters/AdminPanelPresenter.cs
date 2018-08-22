﻿using System;
using System.Collections.Generic;
using System.Linq;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.Infrastructure;
using CandyStore.Contracts.Infrastructure.Utilities;
using CandyStore.DataModel.CandyStoreModels;
using CandyStore.DataModel.Models;

namespace CandyStore.Client.Presenters
{
    public class AdminPanelPresenter : IAdminPanelPresenter
    {
        private readonly ICandyStoreRepository _candyStoreRepository;
        private readonly IImageUtil _imageUtil;

        public AdminPanelPresenter(ICandyStoreRepository candyStoreRepository)
        {
            _candyStoreRepository = candyStoreRepository;
        }

        public IAdminPanelView View { get; set; }

        public OperationValidationResult AddNewCategory(string name, byte[] image)
        {
            var result = new OperationValidationResult()
            {
                Valid = true
            };

            if (string.IsNullOrEmpty(name) || image == null)
            {
                result.Valid = false;
                result.AddErrorMessage("Category image or category name were not set");
                return result;
            }

            _candyStoreRepository.Insert(new Category
            {
                Name = name,
                CategoryImage = image
            });

            return result;
        }

        public OperationValidationResult AddNewProduct(string productPriceString, string productName, string categoryName, byte[] image)
        {
            var result = new OperationValidationResult
            {
                Valid = true
            };

            var isParsed = double.TryParse(productPriceString, out double productPrice);
            if (!isParsed || productPrice < 0)
            {
                result.Valid = false;
                result.AddErrorMessage("Price must be a positive number.");
                return result;
            }

            if (image == null)
            {
                result.Valid = false;
                result.AddErrorMessage("Select an image for the product.");
                return result;
            }

            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(categoryName))
            {
                result.Valid = false;
                result.AddErrorMessage("Type in a valid name for product and category.");
                return result;
            }

            try
            {
                var product = new Product
                {
                    Name = productName,
                    Price = productPrice
                };
                var category = _candyStoreRepository.GetAll<Category>().FirstOrDefault(c => c.Name == categoryName);
                product.Category = category;
                product.ProductImage = image;

                _candyStoreRepository.Insert(product);
            }
            catch (Exception ex)
            {
                result.Valid = false;
                result.AddErrorMessage(ex.Message);
                return result;
            }

            return result;
        }

        public OperationValidationResult DeleteCategory(string categoryName)
        {
            var operationResult = new OperationValidationResult
            {
                Valid = true
            };

            var confirmationResult = View.GetConfirmationResult();
            if (!confirmationResult)
            {
                operationResult.Valid = false;
                return operationResult;
            }

            if (string.IsNullOrEmpty(categoryName))
            {
                operationResult.Valid = false;
                operationResult.AddErrorMessage("You haven't selected product name");
                return operationResult;
            }

            try
            {
                var categoryToDelete = _candyStoreRepository.GetAll<Category>().FirstOrDefault(p => p.Name == categoryName);
                _candyStoreRepository.Delete(categoryToDelete);
            }
            catch (Exception ex)
            {
                operationResult.Valid = false;
                operationResult.AddErrorMessage(ex.Message);
                return operationResult;
            }

            return operationResult;
        }

        public OperationValidationResult DeleteProduct(string productName)
        {
            var operationResult = new OperationValidationResult
            {
                Valid = true
            };

            var confirmationResult = View.GetConfirmationResult();
            if (!confirmationResult)
            {
                operationResult.Valid = false;
                return operationResult;
            }

            if (string.IsNullOrEmpty(productName))
            {
                operationResult.Valid = false;
                operationResult.AddErrorMessage("You haven't selected product name");
                return operationResult;
            }

            try
            {
                var productToDelete = _candyStoreRepository.GetAll<Product>().FirstOrDefault(p => p.Name == productName);
                _candyStoreRepository.Delete(productToDelete);
            }
            catch (Exception ex)
            {
                operationResult.Valid = false;
                operationResult.AddErrorMessage(ex.Message);
                return operationResult;
            }

            return operationResult;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _candyStoreRepository.GetAll<Category>().ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _candyStoreRepository.GetAll<Product>().ToList();
        }
    }
}
