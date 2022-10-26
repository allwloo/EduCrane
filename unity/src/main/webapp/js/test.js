$(function(){
	
	
	/* 페이지에 접속했을 때 유저 정보 불러오는 함수 */
	$.ajax({
		type: 'post',
		url: 'userInfo.do',
		data: "id=4273504",
		
		success:function(list){

			$("tr:eq(1) td:eq(0)").html(list.clientId);
			$("tr:eq(1) td:eq(1)").html(list.level);
			$("tr:eq(1) td:eq(2)").html(list.lotateX);
			$("tr:eq(1) td:eq(3)").html(list.lotateY);
			$("tr:eq(1) td:eq(4)").html(list.lotateZ);
			$("tr:eq(1) td:eq(5)").html(list.exitTime);
			$("tr:eq(1) td:eq(6)").html(list.finTimes);
		}
	})
	
	/* 페이지에 접속했을 때 유저 세팅 불러오는 함수 */
	$.ajax({
		type: 'post',
		url: 'setting.do',
		data: "id=4273504",
		
		success:function(list){

			$('#backsound').val(list.backSound);
			$('#effectsound').val(list.effectSound);
			if(list.voiceType=="1"){
				$('#signal').val();
				}
			else
				$('input:checkbox[id="singal"]').prop("checked", false);
		}
		
	})
	
	/* 수정 click시 setting 변경하는 함수 */
	$('#change').click(function(){
		
		$.ajax({
			type: 'post',
			url: 'changeSetting.do',
			data: {"backSound": $('#backsound').val(),
					"effectSound": $('#effectsound').val(),
					"voiceType":1,
					"isSignalman":1
					},
			dataType: 'json',
			
			
			success : function(json){
				console.log(json);
			},
			error : function(json){
				console.log(json);
			}
		})
	})
})

	var ctx = $('#myChart');
	console.log(ctx);
	var mychart = new Chart(ctx, {
		type: 'bar',
		data: {
			labels: ['월', '화', '수', '목', '금', '토'],
	        datasets: [{
	          label: '학습 시간(분)',
	          data: [12, 19, 23, 25, 22, 39],
	          backgroundColor: [
	            'rgba(255, 99, 132, 0.2)',
	            'rgba(54, 162, 235, 0.2)',
	            'rgba(255, 206, 86, 0.2)',
	            'rgba(75, 192, 192, 0.2)',
	            'rgba(153, 102, 255, 0.2)',
	            'rgba(255, 159, 64, 0.2)'
	          ],
	          borderColor: [
	            'rgba(255, 99, 132, 1)',
	            'rgba(54, 162, 235, 1)',
	            'rgba(255, 206, 86, 1)',
	            'rgba(75, 192, 192, 1)',
	            'rgba(153, 102, 255, 1)',
	            'rgba(255, 159, 64, 1)'
	          ],
	          borderWidth: 1
	        }]
		},
		options:{
			scales: {
				yAxes: [{
					ticks: {
						beginAtZero: true
					}
				}]
			}
		}
	});
	
	  data = {
        datasets: [{
            backgroundColor: ['red','yellow','skyblue'],
            data: [8, 12, 27]
        }],       
        // 라벨의 이름이 툴팁처럼 마우스가 근처에 오면 나타남
        labels: ['고위험군','중위험군','주의'] 
      };

	  // 가운데 구멍이 없는 파이형 차트
	  var ctx1 = document.getElementById("myChart2");
	  var myPieChart = new Chart(ctx1, {
	      type: 'pie',
	      data: data,
	      options: {}
	  });

