using System;

namespace ErrorHandlingExt.Extensions
{
    /// <summary>
    /// Result extension class.
    /// </summary>
    public static partial class ResultExtension
    {
        #region Result

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> from a method call.
        /// </summary>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="action">The method to call.</param>
        /// <returns></returns>
        public static Result OnSuccess(this Result result, Action action)
        {
            if (!result.IsSuccess)
                return result;

            return Result.From(action);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> from a method call.
        /// </summary>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result OnSuccess(this Result result, Func<Result> func)
        {
            if (!result.IsSuccess)
                return result;

            return Result.From(func);
        }

        #endregion

        #region Result<T>

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="action">The method to call.</param>
        /// <returns></returns>
        public static Result<TSource> OnSuccess<TSource>(this Result<TSource> result, Action action)
        {
            if (!result.IsSuccess)
                return result;

            try
            {
                action();

                return result;
            }
            catch (Exception ex)
            {
                return Result<TSource>.FromFailure(ex);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="action">The method to call.</param>
        /// <returns></returns>
        public static Result<TSource> OnSuccess<TSource>(this Result<TSource> result, Action<TSource> action)
        {
            if (!result.IsSuccess)
                return result;

            try
            {
                action(result.Value);

                return result;
            }
            catch (Exception ex)
            {
                return Result<TSource>.FromFailure(ex);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result<TResult> OnSuccess<TSource, TResult>(this Result<TSource> result, Func<TResult> func)
        {
            return result.Map(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result<TResult> OnSuccess<TSource, TResult>(
            this Result<TSource> result, Func<TSource, TResult> func)
        {
            return result.Map(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result<TResult> OnSuccess<TSource, TResult>(
            this Result<TSource> result, Func<Result<TResult>> func)
        {
            return result.Map(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result<TResult> OnSuccess<TSource, TResult>(
            this Result<TSource> result, Func<TSource, Result<TResult>> func)
        {
            return result.Map(func);
        }

        #endregion
    }
}
