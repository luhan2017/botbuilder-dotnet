﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Prompts;
using static Microsoft.Bot.Builder.Prompts.PromptValidatorEx;

namespace Microsoft.Bot.Builder.Dialogs
{
    public class DateTimePrompt : Prompt<DateTimeResult>
    {
        private Prompts.DateTimePrompt _prompt;

        public DateTimePrompt(string culture, PromptValidator<DateTimeResult> validator = null)
        {
            _prompt = new Prompts.DateTimePrompt(culture, validator);
        }

        protected override Task OnPrompt(DialogContext dc, PromptOptions options, bool isRetry)
        {
            if (dc == null)
                throw new ArgumentNullException(nameof(dc));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            if (isRetry)
            {
                if (options.RetryPromptActivity != null)
                {
                    return _prompt.Prompt(dc.Context, options.RetryPromptActivity.AsMessageActivity());
                }
                if (options.RetryPromptString != null)
                {
                    return _prompt.Prompt(dc.Context, options.RetryPromptString, options.RetrySpeak);
                }
            }
            else
            {
                if (options.PromptActivity != null)
                {
                    return _prompt.Prompt(dc.Context, options.PromptActivity);
                }
                if (options.PromptString != null)
                {
                    return _prompt.Prompt(dc.Context, options.PromptString, options.Speak);
                }
            }
            return Task.CompletedTask;
        }

        protected override async Task<DateTimeResult> OnRecognize(DialogContext dc, PromptOptions options)
        {
            if (dc == null)
                throw new ArgumentNullException(nameof(dc));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return await _prompt.Recognize(dc.Context);
        }

    }
}
