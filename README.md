# FastLearningApp
FastLearningApp is a quizz application written in WPF which helps in learning.

## How to use ?
FastLearningApp consumes questions from json file - **data.json**

Example file format **data.json** :
```json 
[
	{
		"Question" : "question?",
		"ImageLink" : " ",
		"Answers":
		[
			{
				"Content": "a",
				"IsValid": false
			},
			{
				"Content": "b",
				"IsValid": true
			},
			{
				"Content": "c",
				"IsValid": false
			},
		]
	},
	{
		"Question" : "question 2?",
		"ImageLink" : " ",
		"Answers":
		[
			{
				"Content": "aaa",
				"IsValid": true
			},
			{
				"Content": "bcc",
				"IsValid": true
			},
			{
				"Content": "ac",
				"IsValid": false
			},
		]
	}
]
  ```

 ## Hotkeys
 There are some hotkeys available:
 - 'Left' and 'Right' key arrows enable moving between questions.
 - Numeric keys 'D1'-'D9' enable answer selection.
 - 'A' key submits current question.
 - 'R' key resets all questions. 
