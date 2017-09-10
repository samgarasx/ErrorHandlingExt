using System;
using System.Threading.Tasks;

namespace ErrorHandlingExt.Extensions.Tasks
{
    /// <summary>
    /// Asynchronous result extension class.
    /// </summary>
    public static partial class AsyncResultExtension
    {
        #region Result

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TResult>(this Task<Result> resultTask, Func<Task<TResult>> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return await Result<TResult>.FromAsync(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TResult>(
            this Task<Result> resultTask, Func<Task<Result<TResult>>> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return await Result<TResult>.FromAsync(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TResult, TError>(
            this Task<Result> resultTask, Func<Task<TResult>> func, TError error)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(error);

            return await Result<TResult, TError>.FromAsync(func, error).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TResult, TError>(
            this Task<Result> resultTask, Func<Task<Result<TResult, TError>>> func, TError error)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(error);

            return await Result<TResult, TError>.FromAsync(func, error).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from a synchronous mapping method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TResult>(this Task<Result> resultTask, Func<TResult> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            return result.Map(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TResult>(
            this Task<Result> resultTask, Func<Result<TResult>> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            return result.Map(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TResult, TError>(
            this Task<Result> resultTask, Func<TResult> func, TError error)
        {
            Result result = await resultTask.ConfigureAwait(false);

            return result.Map(func, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TResult, TError>(
            this Task<Result> resultTask, Func<Result<TResult, TError>> func, TError error)
        {
            Result result = await resultTask.ConfigureAwait(false);

            return result.Map(func, error);
        }

        #endregion

        #region Result<T>

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<Task<TResult>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return await Result<TResult>.FromAsync(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task<TResult>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            try
            {
                TResult value = await func(result.Value).ConfigureAwait(false);

                return Result<TResult>.FromSuccess(value);
            }
            catch (Exception ex)
            {
                return Result<TResult>.FromFailure(ex);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<Task<Result<TResult>>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            return await Result<TResult>.FromAsync(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task<Result<TResult>>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(result.Error);

            try
            {
                return await func(result.Value).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return Result<TResult>.FromFailure(ex);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> Map<TSource>(this Task<Result<TSource>> resultTask, Func<Task> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            try
            {
                await func().ConfigureAwait(false);

                return Result.FromSuccess();
            }
            catch (Exception ex)
            {
                return Result.FromFailure(ex);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> Map<TSource>(this Task<Result<TSource>> resultTask, Func<TSource, Task> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            try
            {
                await func(result.Value).ConfigureAwait(false);

                return Result.FromSuccess();
            }
            catch (Exception ex)
            {
                return Result.FromFailure(ex);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> Map<TSource>(this Task<Result<TSource>> resultTask, Func<Task<Result>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            return await Result.FromAsync(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> Map<TSource>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task<Result>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            try
            {
                return await func(result.Value).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return Result.FromFailure(ex);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TSource, TResult, TError>(
            this Task<Result<TSource>> resultTask, Func<Task<TResult>> func, TError error)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(error);

            return await Result<TResult, TError>.FromAsync(func, error).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TSource, TResult, TError>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task<TResult>> func, TError error)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(error);
            try
            {
                TResult value = await func(result.Value).ConfigureAwait(false);

                return Result<TResult, TError>.FromSuccess(value);
            }
            catch (Exception ex)
            {
                return Result<TResult, TError>.FromFailure(error);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TSource, TResult, TError>(
            this Task<Result<TSource>> resultTask, Func<Task<Result<TResult, TError>>> func, TError error)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(error);

            return await Result<TResult, TError>.FromAsync(func, error).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TSource, TResult, TError>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task<Result<TResult, TError>>> func, TError error)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(error);

            try
            {
                return await func(result.Value).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return Result<TResult, TError>.FromFailure(error);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TResult> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.Map(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, TResult> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.Map(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<Result<TResult>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.Map(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, Result<TResult>> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.Map(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="action">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> Map<TSource>(this Task<Result<TSource>> resultTask, Action action)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.Map(action);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="action">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> Map<TSource>(this Task<Result<TSource>> resultTask, Action<TSource> action)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.Map(action);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> Map<TSource>(this Task<Result<TSource>> resultTask, Func<Result> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.Map(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> Map<TSource>(
            this Task<Result<TSource>> resultTask, Func<TSource, Result> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.Map(func);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TSource, TResult, TError>(
            this Task<Result<TSource>> resultTask, Func<TResult> func, TError error)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.Map(func, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TSource, TResult, TError>(
            this Task<Result<TSource>> resultTask, Func<TSource, TResult> func, TError error)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.Map(func, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TSource, TResult, TError>(
            this Task<Result<TSource>> resultTask, Func<Result<TResult, TError>> func, TError error)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.Map(func, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TSource, TResult, TError>(
            this Task<Result<TSource>> resultTask, Func<TSource, Result<TResult, TError>> func, TError error)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.Map(func, error);
        }

        #endregion

        #region Result<T, E>

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<Task<TResult>> func, TError error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(result.Error);

            return await Result<TResult, TError>.FromAsync(func, error).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, Task<TResult>> func, TError error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(error);

            try
            {
                TResult value = await func(result.Value).ConfigureAwait(false);

                return Result<TResult, TError>.FromSuccess(value);
            }
            catch (Exception ex)
            {
                return Result<TResult, TError>.FromFailure(error);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<Task<Result<TResult, TError>>> func, TError error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(result.Error);

            return await Result<TResult, TError>.FromAsync(func, error).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, Task<Result<TResult, TError>>> func, TError error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult, TError>.FromFailure(error);

            try
            {
                return await func(result.Value).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return Result<TResult, TError>.FromFailure(error);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result> Map<TSource, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<Task> func, Exception error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result.FromFailure(error);

            return await Result.FromAsync(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result> Map<TSource, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, Task> func, Exception error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result.FromFailure(error);

            try
            {
                await func(result.Value).ConfigureAwait(false);

                return Result.FromSuccess();
            }
            catch (Exception ex)
            {
                return Result.FromFailure(ex);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result> Map<TSource, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<Task<Result>> func, Exception error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result.FromFailure(error);

            return await Result.FromAsync(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result> Map<TSource, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, Task<Result>> func, Exception error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result.FromFailure(error);

            try
            {
                return await func(result.Value).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return Result.FromFailure(ex);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<Task<TResult>> func, Exception error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(error);

            return await Result<TResult>.FromAsync(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, Task<TResult>> func, Exception error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(error);

            try
            {
                TResult value = await func(result.Value).ConfigureAwait(false);

                return Result<TResult>.FromSuccess(value);
            }
            catch (Exception ex)
            {
                return Result<TResult>.FromFailure(ex);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<Task<Result<TResult>>> func, Exception error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(error);

            return await Result<TResult>.FromAsync(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, Task<Result<TResult>>> func, Exception error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result<TResult>.FromFailure(error);

            try
            {
                return await func(result.Value).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return Result<TResult>.FromFailure(ex);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TResult> func, TError error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            return result.Map(func, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, TResult> func, TError error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            return result.Map(func, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<Result<TResult, TError>> func, TError error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            return result.Map(func, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> Map<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, Result<TResult, TError>> func, TError error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            return result.Map(func, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="action">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result> Map<TSource, TError>(
            this Task<Result<TSource, TError>> resultTask, Action action, Exception error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            return result.Map(action, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="action">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result> Map<TSource, TError>(
            this Task<Result<TSource, TError>> resultTask, Action<TSource> action, Exception error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            return result.Map(action, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result> Map<TSource, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<Result> func, Exception error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            return result.Map(func, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result> Map<TSource, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, Result> func, Exception error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            return result.Map(func, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TResult> func, Exception error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            return result.Map(func, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, TResult> func, Exception error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            return result.Map(func, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<Result<TResult>> func, Exception error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            return result.Map(func, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> Map<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, Result<TResult>> func, Exception error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            return result.Map(func, error);
        }

        #endregion
    }
}
