# -*- coding: utf-8 -*-
# Generated by Django 1.10.5 on 2017-02-24 19:16
from __future__ import unicode_literals

from django.db import migrations
import django.db.models.manager


class Migration(migrations.Migration):

    dependencies = [
        ('login_reg', '0001_initial'),
    ]

    operations = [
        migrations.AlterModelManagers(
            name='user',
            managers=[
                ('userManager', django.db.models.manager.Manager()),
            ],
        ),
    ]