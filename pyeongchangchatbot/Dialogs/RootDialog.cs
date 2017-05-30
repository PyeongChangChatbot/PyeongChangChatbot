namespace pyeongchangchatbot.Dialogs
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Connector;

#pragma warning disable 1998

    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private const string searchDate = "날짜에 따른 경기일정 조회";
        private const string searchTime = "시간에 따른 경기일정 조회";
        private const string searchEvent = "경기에 따른 경기일정 조회 (더블)";
        private const string eventAlarm = "경기 알람 받아보기 ";
        private const string news = "최신소식 받아보기";
        private const string socialMedia = "평창올림픽 공식소셜미디어 찾기 (더블)";
        private const string tour = "평창 관광명소 추천받기 (더블)";



        /*
        private string name;
        private int age;
        */

        public async Task StartAsync(IDialogContext context)
        {
            /* Wait until the first message is received from the conversation and call MessageReceviedAsync 
             *  to process that message. */
            context.Wait(this.MessageReceivedAsync);
            //await this.SendWelcomeMessageAsync(context);
        }
        
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            /* When MessageReceivedAsync is called, it's passed an IAwaitable<IMessageActivity>. To get the message,
             *  await the result. */

            var message = await result;

            await this.SendWelcomeMessageAsync(context);
        }
        
        
        private async Task SendWelcomeMessageAsync(IDialogContext context)
        {
            PromptDialog.Choice(
               context,
               this.AfterChoiceSelected,
               new[] { searchDate, searchTime, searchEvent, eventAlarm, news, socialMedia, tour },
               "원하는 항목을 골라주세요. (더블) 이라 적혀있는 것은 더블 클릭하세요.",
               "원하는 항목을 골라주세요. (더블) 이라 적혀있는 것은 더블 클릭하세요.",
               attempts: 3);
        }
        

        private async Task AfterChoiceSelected(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                var selection = await result;

                switch (selection)
                {
                    case searchDate:
                        context.Call(new searchDateDialog(), this.playingAfter);
                        break;

                    case searchTime:
                        context.Call(new searchTimeDialog(), this.playingAfter);
                        break;

                    case searchEvent:
                        context.Call(new searchEventDialog(), this.playingAfter);
                        break;

                    case eventAlarm:
                        context.Call(new eventAlarmDialog(), this.playingAfter);
                        break;

                    case news:
                        context.Call(new newsDialog(), this.playingAfter);
                        break;

                    case socialMedia:
                        context.Call(new socialMediaDialog(), this.playingAfter);
                        break;

                    case tour:
                        context.Call(new tourDialog(), this.playingAfter);
                        break;

                }
            }
            catch (TooManyAttemptsException)
            {
                await this.StartAsync(context);
            }
        }






        private async Task playingAfter(IDialogContext context, IAwaitable<string> result)
        {  

            await this.SendWelcomeMessageAsync(context);

        }
        /*
        private async Task searchTimeAfter(IDialogContext context, IAwaitable<string> result)
        {

            await this.SendWelcomeMessageAsync(context);

        }
        private async Task searchEventAfter(IDialogContext context, IAwaitable<string> result)
        {

            await this.SendWelcomeMessageAsync(context);

        }
        private async Task eventAlarmAfter(IDialogContext context, IAwaitable<string> result)
        {

            await this.SendWelcomeMessageAsync(context);

        }
        private async Task newsAfter(IDialogContext context, IAwaitable<string> result)
        {

            await this.SendWelcomeMessageAsync(context);

        }
        private async Task socialMediaAfter(IDialogContext context, IAwaitable<string> result)
        {

            await this.SendWelcomeMessageAsync(context);

        }
        private async Task tourAfter(IDialogContext context, IAwaitable<string> result)
        {

            await this.SendWelcomeMessageAsync(context);

        }
        */





        /*
        private async Task NameDialogResumeAfter(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                this.name = await result;

                context.Call(new AgeDialog(this.name), this.AgeDialogResumeAfter);
            }
            catch (TooManyAttemptsException)
            {
                await context.PostAsync("I'm sorry, I'm having issues understanding you. Let's try again.");

                await this.SendWelcomeMessageAsync(context);
            }
        }







        private async Task AgeDialogResumeAfter(IDialogContext context, IAwaitable<int> result)
        {
            try
            {
                this.age = await result;

                await context.PostAsync($"Your name is { name } and your age is { age }.");

            }
            catch (TooManyAttemptsException)
            {
                await context.PostAsync("I'm sorry, I'm having issues understanding you. Let's try again.");
            }
            finally
            {
                await this.SendWelcomeMessageAsync(context);
            }
        }
        */
                }
            }