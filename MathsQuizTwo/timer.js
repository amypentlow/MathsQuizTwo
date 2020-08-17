(function () {
	var max_time = 60;

	function CountDownTimer() {
		document.getElementById("CountDownTimer").innerHTML = max_time;
		if (max_time == 0) {
			document.getElementById("CountDownTimer").innerHTML = "";
			document.getElementById("QuestionsAndTextBoxes").innerHTML = "You ran out of time!";
			document.getElementById("Submit").innerHTML = "Play Again"
		}
		else {
			max_time--;
			setTimeout(CountDownTimer, 1000);
        }
	}

	if (document.getElementById("hidden").value === "start") {
		CountDownTimer();
	}
	document.getElementById("hidden").value = "start";
}());