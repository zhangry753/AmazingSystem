# -*- coding: utf-8 -*-
# Generated by Django 1.9.8 on 2018-01-01 14:44
from __future__ import unicode_literals

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('news_cluster', '0001_initial'),
    ]

    operations = [
        migrations.AlterField(
            model_name='news',
            name='cluster',
            field=models.IntegerField(blank=True, default=0, null=True, verbose_name='\u6240\u5728\u7c07'),
        ),
        migrations.AlterField(
            model_name='news',
            name='distance',
            field=models.FloatField(blank=True, default=0.0, null=True, verbose_name='\u8ddd\u79bb\u7c07\u5fc3\u8ddd\u79bb'),
        ),
        migrations.AlterField(
            model_name='news',
            name='link',
            field=models.CharField(blank=True, max_length=100, null=True, verbose_name='\u65b0\u95fb\u94fe\u63a5'),
        ),
        migrations.AlterField(
            model_name='news',
            name='stemming',
            field=models.TextField(blank=True, null=True, verbose_name='\u65b0\u95fb\u4e3b\u5e72'),
        ),
        migrations.AlterField(
            model_name='topic',
            name='url',
            field=models.CharField(blank=True, max_length=100, null=True, verbose_name='\u8bdd\u9898\u94fe\u63a5'),
        ),
    ]