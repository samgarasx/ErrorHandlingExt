using System;

namespace ErrorHandlingExt.Extensions
{
    /// <summary>
    /// Result extensions class.
    /// </summary>
    public static class ResultExtension
    {
        #region Success Result Extension

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result<TResult> OnSuccess<TResult>(this Result result, Func<TResult> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = func();

            return Result<TResult>.FromSuccess(value);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result<TResult> OnSuccess<TResult>(this Result result, Func<Result<TResult>> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return func();
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result OnSuccess<TSource>(this Result<TSource> result, Func<TSource, Result> func)
        {
            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            return func(result.Value);
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

            return func();
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> from a method call.
        /// </summary>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="action">The method to call.</param>
        /// <returns></returns>
        public static Result OnSuccess(this Result result, Action action)
        {
            if (result.IsSuccess)
                action();

            return result;
        }
        
        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="action">The method to call.</param>
        /// <returns></returns>
        public static Result<TSource> OnSuccess<TSource>(this Result<TSource> result, Action action)
        {
            if (result.IsSuccess)
                action();

            return result;
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result<TResult> OnSuccess<TSource, TResult>(
            this Result<TSource> result, Func<TSource, TResult> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = func(result.Value);

            return Result<TResult>.FromSuccess(value);
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
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return func(result.Value);
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
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return func();
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
            if (result.IsSuccess)
                action(result.Value);

            return result;
        }

        #endregion

        #region Ensure Result Extension

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> with the given error type from a conditional method call.
        /// </summary>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="predicate">The method to call.</param>
        /// <param name="error">The <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static Result Ensure(this Result result, Func<bool> predicate, Exception error)
        {
            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            if (!predicate())
                return Result.FromFailure(error);

            return Result.FromSuccess();
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> with the given error type from a conditional method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="predicate">The method to call.</param>
        /// <param name="error">The <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static Result<TSource> Ensure<TSource>(
            this Result<TSource> result, Func<TSource, bool> predicate, Exception error)
        {
            if (!result.IsSuccess)
                return Result<TSource>.FromFailure(result.Error);

            if (!predicate(result.Value))
                return Result<TSource>.FromFailure(error);

            return Result<TSource>.FromSuccess(result.Value);
        }
        
        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> with the given error type from a conditional method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="predicate">The method to call.</param>
        /// <param name="error">The <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static Result<TSource> Ensure<TSource>(
            this Result<TSource> result, Func<bool> predicate, Exception error)
        {
            if (!result.IsSuccess)
                return Result<TSource>.FromFailure(result.Error);

            if (!predicate())
                return Result<TSource>.FromFailure(error);

            return Result<TSource>.FromSuccess(result.Value);
        }

        #endregion

        #region Map Result Extension

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a mapping method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result<TResult> Map<TResult>(this Result result, Func<TResult> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = func();

            return Result<TResult>.FromSuccess(value);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a mapping method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result<TResult> Map<TSource, TResult>(this Result<TSource> result, Func<TSource, TResult> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = func(result.Value);

            return Result<TResult>.FromSuccess(value);
        }
        
        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a mapping method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result<TResult> Map<TSource, TResult>(this Result<TSource> result, Func<TResult> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            TResult value = func();
            
            return Result<TResult>.FromSuccess(value);
        }
        
        #endregion

        #region Failure Result Extension

        /// <summary>
        /// Returns a failed <see cref="Result"/> from a method call.
        /// </summary>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="action">The method to call.</param>
        /// <returns></returns>
        public static Result OnFailure(this Result result, Action action)
        {
            if (!result.IsSuccess)
                action();

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
                action(result.Error);

            return result;
        }

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
                action();

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
                action(result.Error);

            return result;
        }

        #endregion
    }
}
