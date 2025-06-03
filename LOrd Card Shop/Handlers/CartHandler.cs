using LOrd_Card_Shop.Factories;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using LOrd_Card_Shop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Handlers
{
    public class CartHandler
    {
        public static Response<Carts> AddCardtoCart(int cardId, int userId, int quantity)
        {
            Carts cart = CartRepository.GetCartByCompositeId(cardId, userId);

            if(cart == null)
            {
                Carts newCart = CartFactory.CreateCart(cardId, userId, quantity);

                CartRepository.CreateCart(newCart);

                return new Response<Carts>
                {
                    Message = "Card added to cart",
                    Success = true,
                    Payload = newCart,
                };
            }

            else
            {
                CartRepository.UpdateQuantity(cart, quantity);

                return new Response<Carts>
                {
                    Message = "Cart updated successfully",
                    Success = true,
                    Payload = cart,
                };
            }
        }

        public static Response<List<Carts>> GetCartsByUserId(int id)
        {
            List<Carts> carts = CartRepository.GetCartsByUserId(id);

            if(carts == null || carts.Count <= 0)
            {
                return new Response<List<Carts>>
                {
                    Message = "No Carts yet...",
                    Success = false,
                };
            }

            else
            {
                return new Response<List<Carts>>
                {
                    Message = "Carts Found!",
                    Success = true,
                    Payload = carts,
                };
            }
        }

        public static Response<Carts> SubtractCartQuantity(int cartId)
        {
            Carts cart = CartRepository.GetCartById(cartId);

            if(cart == null)
            {
                return new Response<Carts>
                {
                    Message = "Cart item not found!",
                    Success = false,
                };
            }

            if(cart.Quantity <= 1)
            {
                CartRepository.RemoveCart(cart);
                return new Response<Carts>
                {
                    Message = "Cart item deleted successfully!",
                    Success = true,
                    Payload = cart,
                };
            }
            else
            {
                CartRepository.SubtractCartQuantity(cartId);
                return new Response<Carts>
                {
                    Message = "Cart item subtracted successfully!",
                    Success = true,
                    Payload = cart,
                };
            }
            
        }
        public static Response<Carts> AddCartQuantity(int cartId)
        {
            Carts cart = CartRepository.AddCartQuantity(cartId);

            if(cart == null)
            {
                return new Response<Carts>
                {
                    Message = "No item found!",
                    Success = false,
                };
            }
            else
            {
                return new Response<Carts>
                {
                    Message = "Items added successfully!",
                    Success = true,
                    Payload = cart,
                };
            }
        }

        public static Response<Carts> RemoveCart(int cartId)
        {
            Carts cart = CartRepository.GetCartById(cartId);
            if(cart != null)
            {
                CartRepository.RemoveCart(cart);
                return new Response<Carts>
                {
                    Message = "Cart item deleted successfully!",
                    Success = true,
                    Payload = cart,
                };
            }
            else
            {
                return new Response<Carts>
                {
                    Message = "Cart item not found!",
                    Success = false,
                };
            }
        }

        public static Response<List<Carts>> RemoveAllCarts(int userId)
        {
            List<Carts> carts = CartRepository.GetCartsByUserId(userId);

            if(carts != null)
            {
                CartRepository.RemoveAllCarts(carts);
                return new Response<List<Carts>>
                {
                    Message = "Cart items deleted successfully",
                    Success = true,
                    Payload = carts,
                };
            }
            else
            {
                return new Response<List<Carts>>
                {
                    Message = "No item cart found",
                    Success = false,
                };
            }
        }
    }
}