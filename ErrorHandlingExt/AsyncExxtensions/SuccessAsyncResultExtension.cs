﻿using System;
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
        /// Returns a successful or failed <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Func<Task> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            return await Result.FromAsync(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from an asynchronous method call.
        /// </summary>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Func<Task<Result>> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            return await Result.FromAsync(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous mapping method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TResult>(
            this Task<Result> resultTask, Func<Task<Result<TResult>>> func)
        {
            return await resultTask.Map(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous mapping method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> OnSuccess<TResult, TError>(
            this Task<Result> resultTask, Func<Task<TResult>> func, TError error)
        {
            return await resultTask.Map(func, error).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous mapping method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> OnSuccess<TResult, TError>(
            this Task<Result> resultTask, Func<Task<Result<TResult, TError>>> func, TError error)
        {
            return await resultTask.Map(func, error).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from a synchronous method call.
        /// </summary>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="action">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Action action)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            return await Result.FromAsync(action).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result"/> task from a synchronous method call.
        /// </summary>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Func<Result> func)
        {
            Result result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return Result.FromFailure(result.Error);

            return await Result.FromAsync(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from a synchronous mapping method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TResult>(this Task<Result> resultTask, Func<TResult> func)
        {
            return await resultTask.Map(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from a synchronous mapping method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TResult>(
            this Task<Result> resultTask, Func<Result<TResult>> func)
        {
            return await resultTask.Map(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous mapping method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> OnSuccess<TResult, TError>(
            this Task<Result> resultTask, Func<TResult> func, TError error)
        {
            return await resultTask.Map(func, error).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous mapping method call.
        /// </summary>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> OnSuccess<TResult, TError>(
            this Task<Result> resultTask, Func<Result<TResult, TError>> func, TError error)
        {
            return await resultTask.Map(func, error).ConfigureAwait(false);
        }

        #endregion

        #region Result<T>

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnSuccess<TSource>(
            this Task<Result<TSource>> resultTask, Func<Task> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return result;

            try
            {
                await func().ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {
                return Result<TSource>.FromFailure(ex);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnSuccess<TSource>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task> func)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return result;

            try
            {
                await func(result.Value).ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {
                return Result<TSource>.FromFailure(ex);
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
        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<Task<TResult>> func)
        {
            return await resultTask.Map(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task<TResult>> func)
        {
            return await resultTask.Map(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<Task<Result<TResult>>> func)
        {
            return await resultTask.Map(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, Task<Result<TResult>>> func)
        {
            return await resultTask.Map(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="action">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnSuccess<TSource>(
            this Task<Result<TSource>> resultTask, Action action)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.OnSuccess(action);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="action">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TSource>> OnSuccess<TSource>(
            this Task<Result<TSource>> resultTask, Action<TSource> action)
        {
            Result<TSource> result = await resultTask.ConfigureAwait(false);

            return result.OnSuccess(action);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TResult> func)
        {
            return await resultTask.Map(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, TResult> func)
        {
            return await resultTask.Map(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<Result<TResult>> func)
        {
            return await resultTask.Map(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T}.Value"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
            this Task<Result<TSource>> resultTask, Func<TSource, Result<TResult>> func)
        {
            return await resultTask.Map(func).ConfigureAwait(false);
        }

        #endregion

        #region Result<T, E>

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TSource, TError>> OnSuccess<TSource, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<Task> func, TError error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return result;

            try
            {
                await func().ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {
                return Result<TSource, TError>.FromFailure(error);
            }
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TSource, TError>> OnSuccess<TSource, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, Task> func, TError error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            if (!result.IsSuccess)
                return result;

            try
            {
                await func(result.Value).ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {
                return Result<TSource, TError>.FromFailure(error);
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
        public static async Task<Result<TResult, TError>> OnSuccess<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<Task<TResult>> func, TError error)
        {
            return await resultTask.Map(func, error).ConfigureAwait(false);
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
        public static async Task<Result<TResult, TError>> OnSuccess<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, Task<TResult>> func, TError error)
        {
            return await resultTask.Map(func, error).ConfigureAwait(false);
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
        public static async Task<Result<TResult, TError>> OnSuccess<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<Task<Result<TResult, TError>>> func, TError error)
        {
            return await resultTask.Map(func, error).ConfigureAwait(false);
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
        public static async Task<Result<TResult, TError>> OnSuccess<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, Task<Result<TResult, TError>>> func, TError error)
        {
            return await resultTask.Map(func, error).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> OnSuccess<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<Task<TResult>> func)
        {
            return await resultTask.Map(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> OnSuccess<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, Task<TResult>> func)
        {
            return await resultTask.Map(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> OnSuccess<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<Task<Result<TResult, TError>>> func)
        {
            return await resultTask.Map(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from an asynchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> OnSuccess<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, Task<Result<TResult, TError>>> func)
        {
            return await resultTask.Map(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="action">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TSource, TError>> OnSuccess<TSource, TError>(
            this Task<Result<TSource, TError>> resultTask, Action action, TError error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            return result.OnSuccess(action, error);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="action">The synchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TSource, TError>> OnSuccess<TSource, TError>(
            this Task<Result<TSource, TError>> resultTask, Action<TSource> action, TError error)
        {
            Result<TSource, TError> result = await resultTask.ConfigureAwait(false);

            return result.OnSuccess(action, error);
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
        public static async Task<Result<TResult, TError>> OnSuccess<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TResult> func, TError error)
        {
            return await resultTask.Map(func, error).ConfigureAwait(false);
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
        public static async Task<Result<TResult, TError>> OnSuccess<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, TResult> func, TError error)
        {
            return await resultTask.Map(func, error).ConfigureAwait(false);
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
        public static async Task<Result<TResult, TError>> OnSuccess<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<Result<TResult, TError>> func, TError error)
        {
            return await resultTask.Map(func, error).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <param name="error">The result <see cref="Result{T, E}.Error"/>.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> OnSuccess<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, Result<TResult, TError>> func, TError error)
        {
            return await resultTask.Map(func, error).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> OnSuccess<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TResult> func)
        {
            return await resultTask.Map(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> OnSuccess<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, TResult> func)
        {
            return await resultTask.Map(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The synchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> OnSuccess<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<Result<TResult, TError>> func)
        {
            return await resultTask.Map(func).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a successful or failed <see cref="Result{T, E}"/> task from a synchronous method call.
        /// </summary>
        /// <typeparam name="TSource">The source <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TResult">The result <see cref="Result{T, E}.Value"/> type.</typeparam>
        /// <typeparam name="TError">The result <see cref="Result{T, E}.Error"/> type.</typeparam>
        /// <param name="resultTask">The source <see cref="Result{T, E}"/> task.</param>
        /// <param name="func">The asynchronous method to call.</param>
        /// <returns></returns>
        public static async Task<Result<TResult, TError>> OnSuccess<TSource, TResult, TError>(
            this Task<Result<TSource, TError>> resultTask, Func<TSource, Result<TResult, TError>> func)
        {
            return await resultTask.Map(func).ConfigureAwait(false);
        }

        #endregion
    }
}
