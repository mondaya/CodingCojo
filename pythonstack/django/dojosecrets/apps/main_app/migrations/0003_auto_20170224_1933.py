# -*- coding: utf-8 -*-
# Generated by Django 1.10.5 on 2017-02-25 03:33
from __future__ import unicode_literals

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('main_app', '0002_auto_20170224_1906'),
    ]

    operations = [
        migrations.RenameField(
            model_name='post',
            old_name='secret',
            new_name='secre1',
        ),
    ]
