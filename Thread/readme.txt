
1.�ΰ����.Main�Gthrd,xxx�N�浹�A�F.
thrd = new Thread(xxx);
thrd.Start();

2.�bWinForm���A���ӳW�w�N�O�إ߱����������~��s���o�ӱ���A�ҥH�p�G�n��s�D������������ܡA�N�n�ΥD�����������
(�]��.NET�W�w���i����������UI���ܤ�)

thrd�GUpdateUI�A�^Main���᪺��,�N�·ЧA�F.
thrd�Gmi�A�ЧA�a�����^��ain�a

MethodInvoker mi = new MethodInvoker(this.UpdateUI);//This delegate can be used when making calls to a control's Invoke method,
this.BeginInvoke(mi, null);
========================================�W�߶}�@��������hwork
�@�k1
            sample = new Thread(_ThreadFunction);
            sample.Start(); 
�@�k2
            BackgroundWorker bgwWorker = new BackgroundWorker();
            bgwWorker.DoWork +=new DoWorkEventHandler(bgwWorker_DoWork);
            bgwWorker.RunWorkerAsync();

========================================thread�Gxxx�A�^�hmain����ooo�a
�@�k1
            MethodInvoker mi = new MethodInvoker(this.UpdateUI);
            this.BeginInvoke(mi, null);
�@�k2
	    bgwWorker.WorkerReportsProgress = true;//�]�� True �~��^���i��, �O BackgroundWorker �����]�p���W�d
		bgwWorker.ProgressChanged += new ProgressChangedEventHandler(bgwWorker_ProgressChanged);
		
		bgwWorker.ReportProgress(i);//�޵oProgressChanged

===============================================