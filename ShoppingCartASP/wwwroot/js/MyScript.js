var qt = [];
var total = [],items;
var shipping,sum,finalResult;
var notifications ;
var options = {
                category:"cart",
                message: "20"
            };
///
 notifications = new $.ttwNotificationMenu(); 
 notifications.initMenu({ cart:'#cart' }); 
 notifications.createNotification({ message:'This is a notification', category:'cart', icon:'css/cart.png' });

$(document).ready(function(){
    qt[0]= parseInt($("#qt0").val());
	console.log(qt[0]);
	qt[1]= parseInt($("#qt1").val());
	qt[2]= parseInt($("#qt2").val());
    $("#total0").text($("#qt0").val()*$("#price0").text());
	$("#total1").text($("#qt1").val()*$("#price1").text());
	$("#total2").text($("#qt2").val()*$("#price2").text());
	if($("#shipping").val()=="Standard Delivery 10 TL")
		shipping=10;
	else
		shipping=8;
	total1 = parseInt($("#total0").text());
	total2 = parseInt($("#total1").text());
	total3 = parseInt($("#total2").text());
	sum=total1+total2+total3;
	shipping=parseInt(shipping);
    finalResult = sum+shipping;
	$("#items").text(parseInt(qt[0])+parseInt(qt[1])+parseInt(qt[2]));
    items=parseInt($("#items").text());
	$("#sum").text(total1+total2+total3);
	$("#final").text(finalResult);
	//$( "a" ).click(function( event ) {
 //    event.preventDefault();
	// });
	$("#remove1").click(function(){
		$("#qt0").val(0);
		$("#price0").text(0);
		update(0);
    $("#prod1").hide();
     });
	$("#remove2").click(function(){
		$("#qt1").val(0);
		$("#price1").text(0);
		$("#prod2").hide();
		update(1);
	});
	$("#remove3").click(function(){
		$("#qt2").val(0);
		$("#price2").text(0);
		$("#prod3").hide();
		update(2);
	});
	$("#add").click(function(){
    $("#code").toggle("slow");
});
});
function update(i,length)
{
   $("#total"+i+"").text($("#qt"+i+"").val()*$("#price"+i+"").text());
    qt[i] = parseInt($("#qt" + i + "").val());
    items = 0;
    sum = 0;
    for (i = 0; i < length; i++) {
        total[i] = parseInt($("#total"+i+"").text());
        items += parseInt(qt[i]);
        sum += total[i];
    }
   $("#items").text(items);
   $("#sum").text(sum); 
   console.log(sum);
   $("#final").text(sum+shipping);
   notifications.initMenu({
       projects:'#projects',
       tasks:'#tasks',       
	   cart:'#cart',
      
    });
   for(i=0;i<items;i++)
        notifications.createNotification(options);
}
function changeFinal()
{
	if($("#shipping").val()=="Standard Delivery 10 TL")
		shipping=10;
	else
		shipping=8;
	shipping=parseInt(shipping);
	finalResult= sum+shipping;
	$("#final").text(finalResult);
}
//////////
