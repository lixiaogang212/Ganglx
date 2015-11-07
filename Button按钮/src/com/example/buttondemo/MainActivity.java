package com.example.buttondemo;

import android.R.color;
import android.app.Activity;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.provider.Settings.SettingNotFoundException;
import android.text.Spannable;
import android.text.SpannableString;
import android.text.style.ImageSpan;
import android.view.Menu;
import android.view.MenuItem;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnFocusChangeListener;
import android.view.View.OnTouchListener;
import android.widget.Button;
import android.widget.Toast;

public class MainActivity extends Activity implements OnTouchListener {
	Button button1;
	Button button2;
	Button button3;
	Button button5;
	int value=1;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		button1=(Button) findViewById(R.id.button1);
		button2=(Button) findViewById(R.id.button2);
		button3=(Button) findViewById(R.id.button3);
		
		button5=(Button) findViewById(R.id.button5);
		
		SpannableString span=new SpannableString("left");
		ImageSpan isp=new ImageSpan(BitmapFactory.decodeResource(getResources(), 
				R.drawable.ic_launcher));
		span.setSpan(isp, 0, 4, Spannable.SPAN_EXCLUSIVE_EXCLUSIVE);
		button5.append(span);
		button5.append("我的按鈕");
		button5.append(span);
		
		
		button1.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				button1.setFocusableInTouchMode(true);
				Toast toast=Toast.makeText(getApplicationContext(), "默认的Toast", Toast.LENGTH_SHORT);  
				toast.show();
			}
		});
		button1.setOnTouchListener(this);//触摸监听
		button3.setOnFocusChangeListener(new OnFocusChangeListener() {//焦点监听
			@Override
			public void onFocusChange(View v, boolean hasFocus) {
				button3.setFocusableInTouchMode(true);
				if(hasFocus)
				{
//					button2.setBackgroundResource(R.drawable.ic_launcher);
					Toast toast=Toast.makeText(getApplicationContext(), "获得焦点", Toast.LENGTH_SHORT);  
					toast.show();
				}
				else
				{
//					button2.setBackgroundResource(R.drawable.windows);
					Toast toast=Toast.makeText(getApplicationContext(), "失去焦点", Toast.LENGTH_SHORT);  
					toast.show();
				}
			}
		});
		button2.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				int width=getWindow().getWindowManager().getDefaultDisplay().getWidth()/2;
//				Toast toast=Toast.makeText(getApplicationContext(), "宽度"+button2.getWidth(), Toast.LENGTH_SHORT);  
//				toast.show();
				if(value==1&&button2.getWidth()>=width)
				{
					value=-1;
				}
				else if(value==-1&&button2.getWidth()<=100)
				{
					value=1;
				}
				button2.setWidth(button2.getWidth()+(int)(button2.getWidth()*0.1)*value);
				button2.setHeight(button2.getHeight()+(int)(button2.getHeight()*0.1)*value);
			}
		});
	}
	@Override
	public boolean onTouch(View v, MotionEvent event) {
		int action=event.getAction();//事件类型
		if(action==MotionEvent.ACTION_DOWN)
		{
			button1.setBackgroundResource(R.drawable.windows);
		}
		else if(action==MotionEvent.ACTION_UP)
		{
			button1.setBackgroundResource(R.drawable.ic_launcher);
		}
		return false;//返回true c处理了此事件  系统不再回调其他的事件监听 （click不再执行）
	}
}
