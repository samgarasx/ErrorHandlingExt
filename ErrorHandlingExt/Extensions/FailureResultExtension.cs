﻿using System;

namespace ErrorHandlingExt.Extensions
{
    /// <summary>
    /// Result extension class.
    /// </summary>
    public static partial class ResultExtension
    {
        #region Result

        /// <summary>
        /// Returns a failed <see cref="Result"/> from a method call.
        /// </summary>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="action">The method to call.</param>
        /// <returns></returns>
        public static Result OnFailure(this Result result, Action action)
        {
            if (!result.IsSuccess)
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    return Result.FromFailure(ex);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a failed <see cref="Result"/> from a method call.
        /// </summary>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="action">The method to call.</param>
        /// <returns></returns>
        public static Result OnFailure(this Result result, Action<Exception> action)
        {
            if (!result.IsSuccess)
            {
                try
                {
                    action(result.Error);
                }
                catch (Exception ex)
                {
                    return Result.FromFailure(ex);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a failed <see cref="Result"/> from a method call.
        /// </summary>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result OnFailure(this Result result, Func<Exception> func)
        {
            if (!result.IsSuccess)
            {
                try
                {
                    Exception error = func();

                    return Result.FromFailure(error);
                }
                catch (Exception ex)
                {
                    return Result.FromFailure(ex);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a failed <see cref="Result"/> from a method call.
        /// </summary>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result OnFailure(this Result result, Func<Exception, Exception> func)
        {
            if (!result.IsSuccess)
            {
                try
                {
                    Exception error = func(result.Error);

                    return Result.FromFailure(error);
                }
                catch (Exception ex)
                {
                    return Result.FromFailure(ex);
                }
            }

            return result;
        }

        #endregion

        #region Result<T>

        /// <summary>
        /// Returns a failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="action">The method to call.</param>
        /// <returns></returns>
        public static Result<TSource> OnFailure<TSource>(this Result<TSource> result, Action action)
        {
            if (!result.IsSuccess)
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    return Result<TSource>.FromFailure(ex);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="action">The method to call.</param>
        /// <returns></returns>
        public static Result<TSource> OnFailure<TSource>(this Result<TSource> result, Action<Exception> action)
        {
            if (!result.IsSuccess)
            {
                try
                {
                    action(result.Error);
                }
                catch (Exception ex)
                {
                    return Result<TSource>.FromFailure(ex);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result<TSource> OnFailure<TSource>(this Result<TSource> result, Func<Exception> func)
        {
            if (!result.IsSuccess)
            {
                try
                {
                    Exception error = func();

                    return Result<TSource>.FromFailure(error);
                }
                catch (Exception ex)
                {
                    return Result<TSource>.FromFailure(ex);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result<TSource> OnFailure<TSource>(this Result<TSource> result, Func<Exception, Exception> func)
        {
            if (!result.IsSuccess)
            {
                try
                {
                    Exception error = func(result.Error);

                    return Result<TSource>.FromFailure(error);
                }
                catch (Exception ex)
                {
                    return Result<TSource>.FromFailure(ex);
                }
            }

            return result;
        }

        #endregion
    }
}
