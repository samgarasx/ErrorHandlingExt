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
        /// Returns a successful or failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result<TResult> Map<TResult>(this Result result, Func<TResult> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return Result<TResult>.From(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result<TResult> Map<TResult>(this Result result, Func<Result<TResult>> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return Result<TResult>.From(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> from a method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static Result<TResult, TError> Map<TResult, TError>(
            this Result result, Func<TResult> func, TError error)
        {
            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(error);

            return Result<TResult, TError>.From(func, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> from a method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static Result<TResult, TError> Map<TResult, TError>(
            this Result result, Func<Result<TResult, TError>> func, TError error)
        {
            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(error);

            return Result<TResult, TError>.From(func, error);
        }

        #endregion

        #region Result<T>

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a method call.
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

            return Result<TResult>.From(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a method call.
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

            try
            {
                TResult value = func(result.Value);

                return Result<TResult>.FromSuccess(value);
            }
            catch (Exception ex)
            {
                return Result<TResult>.FromFailure(ex);
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
        public static Result<TResult> Map<TSource, TResult>(this Result<TSource> result, Func<Result<TResult>> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return Result<TResult>.From(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result<TResult> Map<TSource, TResult>(
            this Result<TSource> result, Func<TSource, Result<TResult>> func)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            try
            {
                return func(result.Value);
            }
            catch (Exception ex)
            {
                return Result<TResult>.FromFailure(ex);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="action">The method to call.</param>
        /// <returns></returns>
        public static Result Map<TSource>(this Result<TSource> result, Action action)
        {
            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            try
            {
                action();

                return Result.FromSuccess();
            }
            catch (Exception ex)
            {
                return Result.FromFailure(ex);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="action">The method to call.</param>
        /// <returns></returns>
        public static Result Map<TSource>(this Result<TSource> result, Action<TSource> action)
        {
            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            try
            {
                action(result.Value);

                return Result.FromSuccess();
            }
            catch (Exception ex)
            {
                return Result.FromFailure(ex);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result Map<TSource>(this Result<TSource> result, Func<Result> func)
        {
            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            return Result.From(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <returns></returns>
        public static Result Map<TSource>(this Result<TSource> result, Func<TSource, Result> func)
        {
            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            try
            {
                return func(result.Value);
            }
            catch (Exception ex)
            {
                return Result.FromFailure(ex);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static Result<TResult, TError> Map<TSource, TResult, TError>(
            this Result<TSource> result, Func<TResult> func, TError error)
        {
            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(error);

            return Result<TResult, TError>.From(func, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static Result<TResult, TError> Map<TSource, TResult, TError>(
            this Result<TSource> result, Func<TSource, TResult> func, TError error)
        {
            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(error);
            try
            {
                TResult value = func(result.Value);

                return Result<TResult, TError>.FromSuccess(value);
            }
            catch (Exception ex)
            {
                return Result<TResult, TError>.FromFailure(error);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static Result<TResult, TError> Map<TSource, TResult, TError>(
            this Result<TSource> result, Func<Result<TResult, TError>> func, TError error)
        {
            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(error);

            return Result<TResult, TError>.From(func, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static Result<TResult, TError> Map<TSource, TResult, TError>(
            this Result<TSource> result, Func<TSource, Result<TResult, TError>> func, TError error)
        {
            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(error);

            try
            {
                return func(result.Value);
            }
            catch (Exception ex)
            {
                return Result<TResult, TError>.FromFailure(error);
            }
        }

        #endregion

        #region Result<T, E>

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T, E}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static Result<TResult, TError> Map<TSource, TResult, TError>(
            this Result<TSource, TError> result, Func<TResult> func, TError error)
        {
            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(result.Error);

            return Result<TResult, TError>.From(func, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T, E}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static Result<TResult, TError> Map<TSource, TResult, TError>(
            this Result<TSource, TError> result, Func<TSource, TResult> func, TError error)
        {
            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(error);

            try
            {
                TResult value = func(result.Value);

                return Result<TResult, TError>.FromSuccess(value);
            }
            catch (Exception ex)
            {
                return Result<TResult, TError>.FromFailure(error);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T, E}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static Result<TResult, TError> Map<TSource, TResult, TError>(
            this Result<TSource, TError> result, Func<Result<TResult, TError>> func, TError error)
        {
            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(result.Error);

            return Result<TResult, TError>.From(func, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T, E}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static Result<TResult, TError> Map<TSource, TResult, TError>(
            this Result<TSource, TError> result, Func<TSource, Result<TResult, TError>> func, TError error)
        {
            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(error);

            try
            {
                return func(result.Value);
            }
            catch (Exception ex)
            {
                return Result<TResult, TError>.FromFailure(error);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T, E}"/>.</param>
        /// <param name="action">The method to call.</param>
        /// <param name="error">The result <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static Result Map<TSource, TError>(this Result<TSource, TError> result, Action action, Exception error)
        {
            if (!result.IsSuccess)
                return Result.FromFailure(error);

            return Result.From(action);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T, E}"/>.</param>
        /// <param name="action">The method to call.</param>
        /// <param name="error">The result <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static Result Map<TSource, TError>(
            this Result<TSource, TError> result, Action<TSource> action, Exception error)
        {
            if (!result.IsSuccess)
                return Result.FromFailure(error);

            try
            {
                action(result.Value);

                return Result.FromSuccess();
            }
            catch (Exception ex)
            {
                return Result.FromFailure(ex);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T, E}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <param name="error">The result <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static Result Map<TSource, TError>(
            this Result<TSource, TError> result, Func<Result> func, Exception error)
        {
            if (!result.IsSuccess)
                return Result.FromFailure(error);

            return Result.From(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T, E}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <param name="error">The result <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static Result Map<TSource, TError>(
            this Result<TSource, TError> result, Func<TSource, Result> func, Exception error)
        {
            if (!result.IsSuccess)
                return Result.FromFailure(error);

            try
            {
                return func(result.Value);
            }
            catch (Exception ex)
            {
                return Result.FromFailure(ex);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T, E}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <param name="error">The result <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static Result<TResult> Map<TSource, TResult, TError>(
            this Result<TSource, TError> result, Func<TResult> func, Exception error)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(error);

            return Result<TResult>.From(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T, E}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <param name="error">The result <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static Result<TResult> Map<TSource, TResult, TError>(
            this Result<TSource, TError> result, Func<TSource, TResult> func, Exception error)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(error);

            try
            {
                TResult value = func(result.Value);

                return Result<TResult>.FromSuccess(value);
            }
            catch (Exception ex)
            {
                return Result<TResult>.FromFailure(ex);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T, E}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <param name="error">The result <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static Result<TResult> Map<TSource, TResult, TError>(
            this Result<TSource, TError> result, Func<Result<TResult>> func, Exception error)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(error);

            return Result<TResult>.From(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> from a method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="result">The source <see cref="Result{T, E}"/>.</param>
        /// <param name="func">The method to call.</param>
        /// <param name="error">The result <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static Result<TResult> Map<TSource, TResult, TError>(
            this Result<TSource, TError> result, Func<TSource, Result<TResult>> func, Exception error)
        {
            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(error);

            try
            {
                return func(result.Value);
            }
            catch (Exception ex)
            {
                return Result<TResult>.FromFailure(ex);
            }
        }

        #endregion
    }
}
