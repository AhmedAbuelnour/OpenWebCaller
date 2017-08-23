# OpenWebCaller
Provide a simple way to make Web API calls asynchronously 

# Get Request: 
`HttpRespondResult RespondResult = await WebCaller.GetAsync("/Student/details/1");`

# Post Request: 
`HttpRespondResult RespondResult = await WebCaller.PostAsync("Url", new StudentViewModel {Id = 1 , Name = "Ahmed"});`

# Put Request: 
`HttpRespondResult RespondResult = await WebCaller.PutAsync("Url", new StudentViewModel {Id = 1 , Name = "Mohamed"});`

# Delete Request: 
`HttpRespondResult RespondResult = await WebCaller.DeleteAsync("/Student/Delete/1");`
